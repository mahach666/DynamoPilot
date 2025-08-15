using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System;

namespace UserState
{
    public static class Parsers
    {
        [IsDesignScriptCompatible]
        public static Guid GetId(PUserState pUserState) => pUserState.Id;

        [IsDesignScriptCompatible]
        public static string GetName(PUserState pUserState) => pUserState.Name;

        [IsDesignScriptCompatible]
        public static  string GetTitle(PUserState pUserState) => pUserState.Title;

        [IsDesignScriptCompatible]
        public static byte[] GetIcon(PUserState pUserState) => pUserState.Icon;

        [IsDesignScriptCompatible]
        public static UserStateColorNames GetColor(PUserState pUserState) => pUserState.Color;

        [IsDesignScriptCompatible]
        public static bool GetIsDeleted(PUserState pUserState) => pUserState.IsDeleted;
    }
}
