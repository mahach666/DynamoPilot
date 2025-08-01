using Ascon.Pilot.SDK;
using DynamoPilot.Data.Contracts;
using System;

namespace DynamoPilot.Data.Wrappers
{
    public class PStateInfo : IWrapper
    {
        private readonly IStateInfo _stateInfo;
        public PStateInfo(IStateInfo stateInfo)
        {
            _stateInfo = stateInfo;
        }
        public override string ToString()
        {
            return $"{_stateInfo.State} ({_stateInfo.Date})";
        }

        public ObjectState State => _stateInfo.State;

        public DateTime Date => _stateInfo.Date;

        public int PersonId => _stateInfo.PersonId;

        public int PositionId => _stateInfo.PositionId;

        public object Unwrap()
        {
            return _stateInfo;
        }
    }
}
