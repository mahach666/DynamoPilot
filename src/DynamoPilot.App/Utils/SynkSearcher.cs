using Ascon.Pilot.SDK;
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

            // Подписываемся на поток результатов поиска
            var subscription = _searchService.Search(query).Subscribe(
                onNext: sr =>
                {
                    // Пропускаем удалённые (Remote) результаты
                    //if (sr.Kind == SearchResultKind.Remote)
                    //    return;

                    result.AddRange(sr.Result);
                    frame.Continue = false;
                },
                onError: _ => frame.Continue = false,
                onCompleted: () => frame.Continue = false);

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
