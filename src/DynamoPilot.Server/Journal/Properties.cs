using System;
using System.Collections.Generic;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace ServerJournal
{
    /// <summary>
    /// Узлы для доступа к полям объектов журналов и запросов.
    /// </summary>
    [NodeCategory("Pilot.Server.Journal.Properties")]
    [NodeDescription("Доступ к полям журналов действий и запросов")]
    public static class Properties
    {
        // DUserAction --------------------------------------------------------

        [NodeName("UserActionId")]
        [IsDesignScriptCompatible]
        public static ulong GetId(DUserAction action) => action.Id;

        [NodeName("UserActionPersonId")]
        [IsDesignScriptCompatible]
        public static int GetPersonId(DUserAction action) => action.PersonId;

        [NodeName("UserActionIp")]
        [IsDesignScriptCompatible]
        public static string GetIp(DUserAction action) => action.Ip;

        [NodeName("UserActionServerDateTime")]
        [IsDesignScriptCompatible]
        public static DateTime GetServerDateTime(DUserAction action) => action.ServerDateTime;

        [NodeName("UserActionEventKind")]
        [IsDesignScriptCompatible]
        public static EventKind GetEventKind(DUserAction action) => action.EventKind;

        [NodeName("UserActionObjectId")]
        [IsDesignScriptCompatible]
        public static Guid GetObjectId(DUserAction action) => action.ObjectId;

        [NodeName("UserActionObjectTypeId")]
        [IsDesignScriptCompatible]
        public static int GetObjectTypeId(DUserAction action) => action.ObjectTypeId;

        [NodeName("UserActionObjectTitle")]
        [IsDesignScriptCompatible]
        public static string GetObjectTitle(DUserAction action) => action.ObjectTitle;

        [NodeName("UserActionChangesetId")]
        [IsDesignScriptCompatible]
        public static Guid GetChangesetId(DUserAction action) => action.ChangesetId;

        [NodeName("UserActionAdditionalInfo")]
        [IsDesignScriptCompatible]
        public static byte[] GetAdditionalInfo(DUserAction action) => action.AdditionalInfo;

        [NodeName("UserActionErrorString")]
        [IsDesignScriptCompatible]
        public static string GetErrorString(DUserAction action) => action.ErrorString;

        [NodeName("UserActionPluginAdditional")]
        [IsDesignScriptCompatible]
        public static string GetPluginAdditional(DUserAction action) => action.PluginAdditional;

        // DAdminAction -------------------------------------------------------

        [NodeName("AdminActionId")]
        [IsDesignScriptCompatible]
        public static ulong GetAdminId(DAdminAction action) => action.Id;

        [NodeName("AdminActionUserName")]
        [IsDesignScriptCompatible]
        public static string GetAdminUserName(DAdminAction action) => action.UserName;

        [NodeName("AdminActionIp")]
        [IsDesignScriptCompatible]
        public static string GetAdminIp(DAdminAction action) => action.Ip;

        [NodeName("AdminActionServerDateTime")]
        [IsDesignScriptCompatible]
        public static DateTime GetAdminServerDateTime(DAdminAction action) => action.ServerDateTime;

        [NodeName("AdminActionEventKind")]
        [IsDesignScriptCompatible]
        public static AdminEventKind GetAdminEventKind(DAdminAction action) => action.EventKind;

        [NodeName("AdminActionAdditionalInfo")]
        [IsDesignScriptCompatible]
        public static byte[] GetAdminAdditionalInfo(DAdminAction action) => action.AdditionalInfo;

        // JournalRequest -----------------------------------------------------

        [NodeName("JournalRequestPersonId")]
        [IsDesignScriptCompatible]
        public static int? GetJournalRequestPersonId(JournalRequest request) => request.PersonId;

        [NodeName("JournalRequestEventKinds")]
        [IsDesignScriptCompatible]
        public static IEnumerable<EventKind> GetJournalRequestEventKinds(JournalRequest request) => request.EventKinds;

        [NodeName("JournalRequestStartDate")]
        [IsDesignScriptCompatible]
        public static DateTime? GetJournalRequestStartDate(JournalRequest request) => request.StartDate;

        [NodeName("JournalRequestEndDate")]
        [IsDesignScriptCompatible]
        public static DateTime? GetJournalRequestEndDate(JournalRequest request) => request.EndDate;

        [NodeName("JournalRequestFromId")]
        [IsDesignScriptCompatible]
        public static ulong? GetJournalRequestFromId(JournalRequest request) => request.FromId;

        [NodeName("JournalRequestCount")]
        [IsDesignScriptCompatible]
        public static int GetJournalRequestCount(JournalRequest request) => request.Count;

        [NodeName("JournalRequestObjectTypesIds")]
        [IsDesignScriptCompatible]
        public static IEnumerable<int> GetJournalRequestObjectTypesIds(JournalRequest request) => request.ObjectTypesIds;

        // AdminJournalRequest -----------------------------------------------

        [NodeName("AdminJournalRequestCount")]
        [IsDesignScriptCompatible]
        public static int GetAdminJournalRequestCount(AdminJournalRequest request) => request.Count;

        [NodeName("AdminJournalRequestFromId")]
        [IsDesignScriptCompatible]
        public static ulong? GetAdminJournalRequestFromId(AdminJournalRequest request) => request.FromId;

        [NodeName("AdminJournalRequestUserName")]
        [IsDesignScriptCompatible]
        public static string GetAdminJournalRequestUserName(AdminJournalRequest request) => request.UserName;

        [NodeName("AdminJournalRequestIp")]
        [IsDesignScriptCompatible]
        public static string GetAdminJournalRequestIp(AdminJournalRequest request) => request.Ip;

        [NodeName("AdminJournalRequestStartDate")]
        [IsDesignScriptCompatible]
        public static DateTime? GetAdminJournalRequestStartDate(AdminJournalRequest request) => request.StartDate;

        [NodeName("AdminJournalRequestEndDate")]
        [IsDesignScriptCompatible]
        public static DateTime? GetAdminJournalRequestEndDate(AdminJournalRequest request) => request.EndDate;

        [NodeName("AdminJournalRequestEventKinds")]
        [IsDesignScriptCompatible]
        public static IEnumerable<AdminEventKind> GetAdminJournalRequestEventKinds(AdminJournalRequest request) => request.EventKinds;
    }
}

