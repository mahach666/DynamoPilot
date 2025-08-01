using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Windows.Threading;

namespace ObjectsRepository
{
    public static class Select
    {
        [IsDesignScriptCompatible]
        public static PilotObjectsRepository ObjectsRepository()
        {
            return StaticMetadata.ObjectsRepository;
        }

        [IsDesignScriptCompatible]
        public static PilotDataObject GetObj(string id)
        {
            return new PilotDataObject(LoadObjects(new[] { new Guid(id) }, default).FirstOrDefault());
        }

        //public static IReadOnlyList<IDataObject> LoadObjects(
        //    IEnumerable<Guid> ids,
        //    CancellationToken ct)
        //{
        //    if (ids is null) throw new ArgumentNullException(nameof(ids));

        //    var loading = ids.ToList();
        //    if (loading.Count == 0)
        //        return Array.Empty<IDataObject>();

        //    var result = new List<IDataObject>();
        //    var dispatcher = Dispatcher.CurrentDispatcher;

        //    var frame = new DispatcherFrame();

        //    var subscription = ((IObjectsRepository)StaticMetadata.ObjectsRepository.Unwrap())
        //        .SubscribeObjects(loading)
        //        .Where(o => o.State == DataState.Loaded)
        //        .Distinct(o => o.Id)
        //        .Subscribe(
        //            obj =>
        //            {
        //                result.Add(obj);
        //                if (result.Count == loading.Count)
        //                    frame.Continue = false;      
        //            },
        //            _ => frame.Continue = false,       
        //            () => frame.Continue = false);      

        //    using var _ = ct.Register(() => frame.Continue = false);

        //    Dispatcher.PushFrame(frame);

        //    subscription.Dispose();

        //    ct.ThrowIfCancellationRequested();

        //    return result.AsReadOnly();
        //}

        public static IReadOnlyList<IDataObject> LoadObjects(
            IEnumerable<Guid> ids,
            CancellationToken ct,
            TimeSpan? waitTimeout = null)    
        {
            if (ids is null) throw new ArgumentNullException(nameof(ids));

            var loading = ids.ToList();
            if (loading.Count == 0)
                return Array.Empty<IDataObject>();

            var dispatcher = Dispatcher.CurrentDispatcher;
            var frame = new DispatcherFrame();

            var result = new List<IDataObject>();
            var seen = new HashSet<Guid>();

            bool IsFinal(DataState s) =>
                s == DataState.Loaded ||
                s == DataState.NoData ||
                s == DataState.NonExistent;

            var subscription = ((IObjectsRepository)StaticMetadata.ObjectsRepository.Unwrap())
                .SubscribeObjects(loading)
                .Subscribe(obj =>
                {
                    if (!IsFinal(obj.State)) return;

                    if (obj.State == DataState.Loaded)
                        result.Add(obj);

                    if (seen.Add(obj.Id) && seen.Count == loading.Count)
                        frame.Continue = false;       
                },
                _ => frame.Continue = false);

            using var _ = ct.Register(() => frame.Continue = false);

            DispatcherTimer? timer = null;
            if (waitTimeout is { } ts)
            {
                timer = new DispatcherTimer(ts, DispatcherPriority.Send,
                    (_, __) => frame.Continue = false,
                    dispatcher);
                timer.Start();
            }

            Dispatcher.PushFrame(frame);

            timer?.Stop();
            subscription.Dispose();
            ct.ThrowIfCancellationRequested();

            return result.AsReadOnly();
        }
    }
}