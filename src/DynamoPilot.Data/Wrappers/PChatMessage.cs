using Ascon.Pilot.SDK.Data;
using DynamoPilot.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamoPilot.Data.Wrappers
{
    public class PChatMessage : IWrapper
    {
        private readonly IChatMessage _chatMessage;
        public PChatMessage(IChatMessage chatMessage)
        {
            _chatMessage = chatMessage;
        }

        public Guid Id => _chatMessage.Id;

        public byte[] Data => _chatMessage.Data;

        public int CreatorId => _chatMessage.CreatorId;

        public DateTime? ServerDateUtc => _chatMessage.ServerDateUtc;

        public DateTime ClientDateUtc => _chatMessage.ClientDateUtc;

        public Guid ChatId => _chatMessage.ChatId;

        public Guid? RelatedMessageId => _chatMessage.RelatedMessageId;

        public MessageType Type => _chatMessage.Type;

        public List<PChatMessage> RelatedMessages => _chatMessage.RelatedMessages.Select(i=> new PChatMessage(i)).ToList();

        public T GetData<T>()
        {
           return _chatMessage.GetData<T>();
        }

        public object Unwrap()
        {
            return _chatMessage;
        }
    }
}
