using Ascon.Pilot.SDK.Data;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System;

namespace Chat
{
    public static class Properties
    {
        [IsDesignScriptCompatible]
        public static Guid Id(PChat pChat) => pChat.Id;

        [IsDesignScriptCompatible]
        public static string Name(PChat pChat) => pChat.Name;

        [IsDesignScriptCompatible]
        public static string Description(PChat pChat) => pChat.Description;

        [IsDesignScriptCompatible]
        public static int CreatorId(PChat pChat) => pChat.CreatorId;

        [IsDesignScriptCompatible]
        public static ChatKind Type(PChat pChat) => pChat.Type;

        [IsDesignScriptCompatible]
        public static Guid? LastMessageId(PChat pChat) => pChat.LastMessageId;

        [IsDesignScriptCompatible]
        public static DateTime CreationDateUtc(PChat pChat) => pChat.CreationDateUtc;
    }
}
