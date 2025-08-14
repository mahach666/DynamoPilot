using Ascon.Pilot.SDK;
using DynamoPilot.Data.Contracts;
using System;

namespace DynamoPilot.Data.Wrappers
{
    public class PUserState : IUserState, IWrapper
    {
        private IUserState _userState;
        public PUserState(IUserState userState)
        {
            _userState = userState;
        }
        public override string ToString()
        {
            return $"{Name} ({Id})";
        }
        public Guid Id => _userState.Id;

        public string Name => _userState.Name;

        public string Title => _userState.Title;

        public byte[] Icon => _userState.Icon;

        public UserStateColorNames Color => _userState.Color;

        public bool IsDeleted => _userState.IsDeleted;

        public object Unwrap()
        {
            return _userState;
        }
    }
}
