using Ascon.Pilot.SDK.Data;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatMessage
{
    public static class Properties
    {
        [IsDesignScriptCompatible]
        public static Guid GetId(PChatMessage pChatMessage) => pChatMessage.Id;

        [IsDesignScriptCompatible]
        public static byte[] GetData(PChatMessage pChatMessage) => pChatMessage.Data;

        [IsDesignScriptCompatible]
        public static int GetCreatorId(PChatMessage pChatMessage) => pChatMessage.CreatorId;

        [IsDesignScriptCompatible]
        public static DateTime? GetServerDateUtc(PChatMessage pChatMessage) => pChatMessage.ServerDateUtc;

        [IsDesignScriptCompatible]
        public static DateTime GetClientDateUtc(PChatMessage pChatMessage) => pChatMessage.ClientDateUtc;

        [IsDesignScriptCompatible]
        public static Guid GetChatId(PChatMessage pChatMessage) => pChatMessage.ChatId;

        [IsDesignScriptCompatible]
        public static Guid? GetRelatedMessageId(PChatMessage pChatMessage) => pChatMessage.RelatedMessageId;

        [IsDesignScriptCompatible]
        public static MessageType GetType(PChatMessage pChatMessage) => pChatMessage.Type;

        [IsDesignScriptCompatible]
        public static List<PChatMessage> GetRelatedMessages(PChatMessage pChatMessage) => pChatMessage.RelatedMessages.Select(i => new PChatMessage(i)).ToList();
    }
}
