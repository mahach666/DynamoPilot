using System.Collections.Generic;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace SOrganisationUnit
{
    /// <summary>
    /// Узлы для получения свойств организационной единицы (DOrganisationUnit).
    /// </summary>
    [NodeCategory("Pilot.Server.OrganisationUnit.Properties")]
    [NodeDescription("Доступ к полям организационной единицы")]
    public static class Properties
    {
        [NodeName("Id")]
        [IsDesignScriptCompatible]
        public static int GetId(DOrganisationUnit orgUnit) => orgUnit.Id;

        [NodeName("Title")]
        [IsDesignScriptCompatible]
        public static string GetTitle(DOrganisationUnit orgUnit) => orgUnit.Title;

        [NodeName("Kind")]
        [IsDesignScriptCompatible]
        public static OrgUnitKind GetKind(DOrganisationUnit orgUnit) => orgUnit.Kind;

        [NodeName("Children")]
        [IsDesignScriptCompatible]
        public static IList<int> GetChildren(DOrganisationUnit orgUnit) => orgUnit.Children;

        [NodeName("IsDeleted")]
        [IsDesignScriptCompatible]
        public static bool GetIsDeleted(DOrganisationUnit orgUnit) => orgUnit.IsDeleted;

        [NodeName("IsBoss")]
        [IsDesignScriptCompatible]
        public static bool GetIsBoss(DOrganisationUnit orgUnit) => orgUnit.IsBoss;

        [NodeName("IsCanceled")]
        [IsDesignScriptCompatible]
        public static bool GetIsCanceled(DOrganisationUnit orgUnit) => orgUnit.IsCanceled;

        [NodeName("Version")]
        [IsDesignScriptCompatible]
        public static long GetVersion(DOrganisationUnit orgUnit) => orgUnit.LastChange;

        [NodeName("Person")]
        [IsDesignScriptCompatible]
        public static int GetPerson(DOrganisationUnit orgUnit) => orgUnit.Person;

        [NodeName("VicePersons")]
        [IsDesignScriptCompatible]
        public static IList<int> GetVicePersons(DOrganisationUnit orgUnit) => orgUnit.VicePersons;

        [NodeName("GroupPersons")]
        [IsDesignScriptCompatible]
        public static IList<int> GetGroupPersons(DOrganisationUnit orgUnit) => orgUnit.GroupPersons;
    }
}

