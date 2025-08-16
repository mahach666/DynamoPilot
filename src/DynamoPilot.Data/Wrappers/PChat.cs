using Ascon.Pilot.SDK.Data;
using DynamoPilot.Data.Contracts;
using System;

namespace DynamoPilot.Data.Wrappers
{
    public class PChat : IWrapper
    {
        private readonly IChat _chat;
        public PChat(IChat chat)
        {
            _chat = chat;
        }
        public override string ToString() => $"{Name} ({Id.ToString()})";
        public Guid Id => _chat.Id;

        public string Name => _chat.Name;

        public string Description => _chat.Description;

        public int CreatorId => _chat.CreatorId;

        public ChatKind Type => _chat.Type;

        public Guid? LastMessageId => _chat.LastMessageId;

        public DateTime CreationDateUtc => _chat.CreationDateUtc;

        public object Unwrap()
        {
            return _chat;
        }
    }
}
