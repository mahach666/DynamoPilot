using Ascon.Pilot.SDK.Data;
using DynamoPilot.Data.Contracts;
using System;

namespace DynamoPilot.Data.Wrappers
{
    public class PHistoryItem : IWrapper
    {
        private readonly IHistoryItem _historyItem;
        public PHistoryItem(IHistoryItem historyItem)
        {
            _historyItem = historyItem;
        }

        public override string ToString()
        {
            return $"{_historyItem.ObjectId} - {_historyItem.Reason} - {_historyItem.Created}";
        }

        public Guid Id => _historyItem.Id;

        public Guid ObjectId => _historyItem.ObjectId;

        public string Reason => _historyItem.Reason;

        public DateTime Created => _historyItem.Created;

        public int CreatorId => _historyItem.CreatorId;

        public PDataObject Object => new(_historyItem.Object);

        public object Unwrap()
        {
            return _historyItem;
        }
    }
}
