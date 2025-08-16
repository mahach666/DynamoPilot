using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System;

namespace Relation
{
    public static class Properties
    {
        [IsDesignScriptCompatible]
        public static Guid GetId(PRelation pRelation) => pRelation.Id;

        [IsDesignScriptCompatible]
        public static Guid GetTargetId(PRelation pRelation) => pRelation.TargetId;

        [IsDesignScriptCompatible]
        public static ObjectRelationType GetType(PRelation pRelation) => pRelation.Type;

        [IsDesignScriptCompatible]
        public static string GetName(PRelation pRelation) => pRelation.Name;

        [IsDesignScriptCompatible]
        public static DateTime GetVersionId(PRelation pRelation) => pRelation.VersionId;
    }
}
