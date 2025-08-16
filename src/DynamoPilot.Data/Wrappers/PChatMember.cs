using Ascon.Pilot.SDK.Data;
using DynamoPilot.Data.Contracts;
using System;

namespace DynamoPilot.Data.Wrappers
{
    public class PChatMember : IWrapper
    {
        private readonly IChatMember _chatMember;
        public PChatMember(IChatMember chatMember)
        {
            _chatMember = chatMember;
        }
        public Guid ChatId => _chatMember.ChatId;

        public int PersonId => _chatMember.PersonId;

        public bool IsAdmin => _chatMember.IsAdmin;

        public bool IsDeleted => _chatMember.IsDeleted;

        public bool IsNotifiable => _chatMember.IsNotifiable;

        public DateTime DateUpdatedUtc => _chatMember.DateUpdatedUtc;

        public bool IsViewerOnly => _chatMember.IsViewerOnly;

        public object Unwrap()
        {
            return _chatMember;
        }
    }
}
