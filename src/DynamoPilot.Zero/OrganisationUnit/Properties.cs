using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System.Collections.ObjectModel;

namespace OrganisationUnit
{
    public static class Properties
    {
        [IsDesignScriptCompatible]
        public static int GetId(POrganisationUnit pOrganisationUnit) => pOrganisationUnit.Id;

        [IsDesignScriptCompatible]
        public static string GetTitle(POrganisationUnit pOrganisationUnit) => pOrganisationUnit.Title;

        [IsDesignScriptCompatible]
        public static bool GetIsDeleted(POrganisationUnit pOrganisationUnit) => pOrganisationUnit.IsDeleted;

        [IsDesignScriptCompatible]
        public static ReadOnlyCollection<int> GetChildren(POrganisationUnit pOrganisationUnit) => pOrganisationUnit.Children;

        [IsDesignScriptCompatible]
        public static bool GetIsPosition(POrganisationUnit pOrganisationUnit) => pOrganisationUnit.IsPosition;

        [IsDesignScriptCompatible]
        public static bool GetIsChief(POrganisationUnit pOrganisationUnit) => pOrganisationUnit.IsChief;

        [IsDesignScriptCompatible]
        public static int Person(POrganisationUnit pOrganisationUnit) => pOrganisationUnit.Person();
    }
}
