using Ascon.Pilot.SDK;
using Ascon.Pilot.SDK.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Threading;

namespace DynamoPilot.App.Utils
{
	public class SynkHistoryItemLoader
	{
		private readonly IObjectsRepository _objectsRepository;
		public SynkHistoryItemLoader(IObjectsRepository objectsRepository)
		{
			_objectsRepository = objectsRepository;
		}

		public IReadOnlyList<IHistoryItem> LoadHistoryItems(
			IEnumerable<Guid> ids,
			CancellationToken ct,
			TimeSpan? waitTimeout = null)
		{
			if (ids is null) throw new ArgumentNullException(nameof(ids));

			var loading = ids.ToList();
			if (loading.Count == 0)
				return Array.Empty<IHistoryItem>();

			var dispatcher = Dispatcher.CurrentDispatcher;
			var frame = new DispatcherFrame();

			var result = new List<IHistoryItem>();

			var subscription = _objectsRepository
				.GetHistoryItems(loading)
				.Subscribe(
					onNext: item =>
					{
						result.Add(item);
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

			return result.AsReadOnly();
		}
	}
}



