using Ascon.Pilot.SDK;
using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;

namespace DynamoPilot.App.Utils
{
    public static class PilotSync
    {
        /// <summary>Блокирующая загрузка объекта с тайм-аутом.</summary>
        public static IDataObject LoadObjSync(
            this IObjectsRepository repo,
            Guid id,
            long minCs = 0,
            int timeoutMs = 3000)
        {
            using var mre = new ManualResetEventSlim();
            IDataObject result = null;
            Exception error = null;

            repo.LoadObjects(new[] { id });                         // ① инициируем загрузку

            var sub = repo.SubscribeObjects(new[] { id })
                          .ObserveOn(ThreadPoolScheduler.Instance)  // Rx перенаправляет вызовы
                          .Subscribe(obj =>
                          {
                              // ② снимаем строгий фильтр по State, если нужно
                              if (obj.State != DataState.Loaded &&
                                  obj.State != DataState.Normal)
                                  return;

                              if (obj.LastChange() < minCs) return;

                              result = obj;
                              mre.Set();
                          },
                          ex => { error = ex; mre.Set(); });

            if (!mre.Wait(timeoutMs))
                throw new TimeoutException(
                    $"Pilot object {id} not loaded in {timeoutMs} ms.");

            sub.Dispose();
            if (error != null) throw error;
            return result!;
        }
    }
}
