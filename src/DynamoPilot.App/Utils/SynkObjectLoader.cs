using Ascon.Pilot.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Threading;

namespace DynamoPilot.App.Utils
{
    public class SynkObjectLoader
    {
        private readonly IObjectsRepository _objectsRepository;

        public SynkObjectLoader(IObjectsRepository objectsRepository)
        {
            _objectsRepository = objectsRepository;
        }

        public IReadOnlyList<IDataObject> LoadObjects(
            IEnumerable<Guid> ids,
            CancellationToken ct,
            TimeSpan? waitTimeout = null)
        {
            if (ids is null) throw new ArgumentNullException(nameof(ids));

            var loading = ids.Distinct().ToList();
            if (loading.Count == 0)
                return Array.Empty<IDataObject>();

            ct.ThrowIfCancellationRequested();

            var loadedById = new Dictionary<Guid, IDataObject>();
            var resolved = new HashSet<Guid>();

            TryLoadBatch(loading, ct, waitTimeout, loadedById, resolved);

            if (resolved.Count < loading.Count)
            {
                foreach (var id in loading)
                {
                    if (resolved.Contains(id))
                        continue;

                    ct.ThrowIfCancellationRequested();
                    TryLoadBatch(new[] { id }, ct, waitTimeout, loadedById, resolved);
                }
            }

            ct.ThrowIfCancellationRequested();

            var ordered = loading
                .Where(id => loadedById.ContainsKey(id))
                .Select(id => loadedById[id])
                .ToList();

            return ordered.AsReadOnly();
        }

        private void TryLoadBatch(
            IEnumerable<Guid> ids,
            CancellationToken ct,
            TimeSpan? waitTimeout,
            IDictionary<Guid, IDataObject> loadedById,
            ISet<Guid> resolved)
        {
            var loading = ids.Distinct().ToList();
            if (loading.Count == 0)
                return;

            var loadingSet = new HashSet<Guid>(loading);
            var seenInBatch = new HashSet<Guid>();
            var dispatcher = Dispatcher.CurrentDispatcher;
            var frame = new DispatcherFrame();
            IDisposable subscription = null;
            DispatcherTimer timer = null;

            bool IsFinal(DataState s) =>
                s == DataState.Loaded ||
                s == DataState.NonExistent;

            try
            {
                subscription = _objectsRepository
                    .SubscribeObjects(loading)
                    .Subscribe(
                        onNext: obj =>
                        {
                            if (obj == null || !loadingSet.Contains(obj.Id) || !IsFinal(obj.State))
                                return;

                            if (obj.State == DataState.Loaded)
                                loadedById[obj.Id] = obj;

                            if (seenInBatch.Add(obj.Id))
                                resolved.Add(obj.Id);

                            if (seenInBatch.Count == loading.Count)
                                frame.Continue = false;
                        },
                        onError: _ => frame.Continue = false,
                        onCompleted: () => frame.Continue = false);

                using var _ = ct.Register(() => frame.Continue = false);
                if (waitTimeout is { } ts)
                {
                    timer = new DispatcherTimer(ts, DispatcherPriority.Send,
                        (_, __) => frame.Continue = false,
                        dispatcher);
                    timer.Start();
                }

                Dispatcher.PushFrame(frame);
            }
            catch (InvalidOperationException)
            {
                // Pilot SDK может вернуть исключение для отдельного id; вызывающий код использует fallback.
            }
            catch (System.Reflection.TargetInvocationException)
            {
                // Ошибка, проброшенная через dispatcher, не должна ронять вызывающий код.
            }
            finally
            {
                timer?.Stop();
                subscription?.Dispose();
            }
        }
    }
}
