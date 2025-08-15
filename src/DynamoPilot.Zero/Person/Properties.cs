using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Person
{
    public static class Properties
    {
        [IsDesignScriptCompatible]
        public static int GetId(PPerson pPerson) => pPerson.Id;

        [IsDesignScriptCompatible]
        public static string GetLogin(PPerson pPerson) => pPerson.Login;

        [IsDesignScriptCompatible]
        public static string GetDisplayName(PPerson pPerson) => pPerson.DisplayName;

        [IsDesignScriptCompatible]
        public static ReadOnlyCollection<PPosition> GetPositions(PPerson pPerson)
            => new ReadOnlyCollection<PPosition>(pPerson.Positions.Select(i => new PPosition(i)).ToList());

        [IsDesignScriptCompatible]
        public static PPosition GetMainPosition(PPerson pPerson) => new(pPerson.MainPosition);

        [IsDesignScriptCompatible]
        public static string GetComment(PPerson pPerson) => pPerson.Comment;

        [IsDesignScriptCompatible]
        public static string GetServiceInfo(PPerson pPerson) => pPerson.ServiceInfo;

        [IsDesignScriptCompatible]
        public static string GetSid(PPerson pPerson) => pPerson.Sid;

        [IsDesignScriptCompatible]
        public static bool GetIsDeleted(PPerson pPerson) => pPerson.IsDeleted;

        [IsDesignScriptCompatible]
        public static bool GetIsAdmin(PPerson pPerson) => pPerson.IsAdmin;

        [IsDesignScriptCompatible]
        public static string GetActualName(PPerson pPerson) => pPerson.ActualName;

        [IsDesignScriptCompatible]
        public static DateTime GetCreatedUtc(PPerson pPerson) => pPerson.CreatedUtc;
    }
}
