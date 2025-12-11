using System;
using System.Collections.Generic;
using System.Linq;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace SObject
{
    /// <summary>
    /// Узлы для получения свойств объекта данных (DObject) через серверное API.
    /// </summary>
    [NodeCategory("Pilot.Server.Object.Properties")]
    [NodeDescription("Доступ к полям DObject")]
    public static class Properties
    {
        [NodeName("Id")]
        [IsDesignScriptCompatible]
        public static Guid GetId(DObject obj) => obj.Id;

        [NodeName("TypeId")]
        [IsDesignScriptCompatible]
        public static int GetTypeId(DObject obj) => obj.TypeId;

        [NodeName("ParentId")]
        [IsDesignScriptCompatible]
        public static Guid GetParentId(DObject obj) => obj.ParentId;

        [NodeName("CreatorId")]
        [IsDesignScriptCompatible]
        public static int GetCreatorId(DObject obj) => obj.CreatorId;

        [NodeName("LastChange")]
        [IsDesignScriptCompatible]
        public static long GetLastChange(DObject obj) => obj.LastChange;

        [NodeName("Created")]
        [IsDesignScriptCompatible]
        public static DateTime GetCreated(DObject obj) => obj.Created;

        [NodeName("Attributes")]
        [IsDesignScriptCompatible]
        public static IDictionary<string, DValue> GetAttributes(DObject obj) => obj.Attributes;

        [NodeName("ActualFileSnapshot")]
        [IsDesignScriptCompatible]
        public static DFilesSnapshot GetActualFileSnapshot(DObject obj) => obj.ActualFileSnapshot;

        [NodeName("PreviousFileSnapshots")]
        [IsDesignScriptCompatible]
        public static IList<DFilesSnapshot> GetPreviousFileSnapshots(DObject obj) => obj.PreviousFileSnapshots;

        [NodeName("Relations")]
        [IsDesignScriptCompatible]
        public static IList<DRelation> GetRelations(DObject obj) => obj.Relations;

        [NodeName("Children")]
        [IsDesignScriptCompatible]
        public static IList<DChild> GetChildren(DObject obj) => obj.Children;

        [NodeName("HistoryItems")]
        [IsDesignScriptCompatible]
        public static IList<Guid> GetHistoryItems(DObject obj) => obj.HistoryItems;

        [NodeName("Context")]
        [IsDesignScriptCompatible]
        public static IList<Guid> GetContext(DObject obj) => obj.Context;

        [NodeName("Subscribers")]
        [IsDesignScriptCompatible]
        public static IList<int> GetSubscribers(DObject obj) => obj.Subscribers?.ToList() ?? new List<int>();

        [NodeName("Access")]
        [IsDesignScriptCompatible]
        public static IList<AccessRecord> GetAccess(DObject obj) => obj.Access;

        [NodeName("StateInfo")]
        [IsDesignScriptCompatible]
        public static DStateInfo GetStateInfo(DObject obj) => obj.StateInfo;

        [NodeName("SecretInfo")]
        [IsDesignScriptCompatible]
        public static SecretInfo GetSecretInfo(DObject obj) => obj.SecretInfo;

        [NodeName("IsSecret")]
        [IsDesignScriptCompatible]
        public static bool GetIsSecret(DObject obj) => obj.IsSecret;

        [NodeName("IsDeleted")]
        [IsDesignScriptCompatible]
        public static bool GetIsDeleted(DObject obj) => obj.IsDeleted;

        [NodeName("IsInRecycleBin")]
        [IsDesignScriptCompatible]
        public static bool GetIsInRecycleBin(DObject obj) => obj.IsInRecycleBin;
    }
}

