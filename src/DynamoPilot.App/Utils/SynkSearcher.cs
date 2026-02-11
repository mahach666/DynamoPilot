using Ascon.Pilot.SDK;
using Ascon.Pilot.SDK.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Threading;

namespace DynamoPilot.App.Utils
{
    public class SynkSearcher
    {
        private readonly ISearchService _searchService;

        public SynkSearcher(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public IReadOnlyList<Guid> Search(
            IQueryBuilder query,
            CancellationToken ct,
            TimeSpan? waitTimeout = null)
        {
            if (_searchService is null) throw new ArgumentNullException(nameof(_searchService));
            if (query is null) throw new ArgumentNullException(nameof(query));

            var dispatcher = Dispatcher.CurrentDispatcher;
            var frame = new DispatcherFrame();

            var result = new List<Guid>();
            var localFallback = new List<Guid>();
            var hasRemote = false;

            var subscription = _searchService.Search(query).Subscribe(
                onNext: sr =>
                {
                    if (sr.Kind == SearchResultKind.Local)
                    {
                        localFallback.AddRange(sr.Result);
                        return;
                    }

                    if (sr.Kind == SearchResultKind.Remote)
                    {
                        hasRemote = true;
                        result.Clear();
                        result.AddRange(sr.Result);
                        frame.Continue = false;
                        return;
                    }

                    result.Clear();
                    result.AddRange(sr.Result);
                    frame.Continue = false;
                },
                onError: _ => frame.Continue = false,
                onCompleted: () =>
                {
                    if (!hasRemote && localFallback.Count > 0)
                        result.AddRange(localFallback);

                    frame.Continue = false;
                });

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

            return result.Distinct().ToList().AsReadOnly();
        }
    }
}
