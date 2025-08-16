using Ascon.Pilot.SDK.Data;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatMessage
{
    public static class Properties
    {
        [IsDesignScriptCompatible]
        public static Guid GetId(PChatMessage pChatMessage) => pChatMessage.Id;

        [IsDesignScriptCompatible]
        public static byte[] GetByteData(PChatMessage pChatMessage) => pChatMessage.Data;

        [IsDesignScriptCompatible]
        public static string GetStringData(PChatMessage pChatMessage) => Encoding.UTF8.GetString(pChatMessage.Data);

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
        public static List<PChatMessage> GetRelatedMessages(PChatMessage pChatMessage) 
            => pChatMessage.RelatedMessages
            .Select(i => new PChatMessage((IChatMessage)i.Unwrap()))
            .ToList();

        //public static string GetStringData(PChatMessage pChatMessage)
        //{
        //    return pChatMessage.GetData<string>();
        //}
    }
}
