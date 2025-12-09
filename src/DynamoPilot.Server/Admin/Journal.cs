using System;
using System.Collections.Generic;
using Ascon.Pilot.DataClasses;
using Ascon.Pilot.Server.Api.Contracts;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace ServerAdmin
{
    /// <summary>
    /// Узлы для работы с журналами действий через Admin API.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.Journal")]
    [NodeDescription("Получение и сборка запросов к журналам")]
    public static class Journal
    {
        [NodeName("GetUserJournal")]
        [IsDesignScriptCompatible]
        public static IList<DUserAction> GetUserJournal(ServerSession session, JournalRequest request)
        {
            var admin = SessionGuard.EnsureAdmin(session);
            return admin.GetJournalItems(request);
        }

        [NodeName("GetAdminJournal")]
        [IsDesignScriptCompatible]
        public static IList<DAdminAction> GetAdminJournal(ServerSession session, AdminJournalRequest request)
        {
            var admin = SessionGuard.EnsureAdmin(session);
            return admin.GetAdminJournalItems(request);
        }

        [NodeName("MakeJournalRequest")]
        [IsDesignScriptCompatible]
        public static JournalRequest MakeJournalRequest(
            string personId = null,
            EventKind[] eventKinds = null,
            string startDate = null,
            string endDate = null,
            string fromId = null,
            int count = 100,
            int[] objectTypesIds = null)
        {
            int? parsedPerson = int.TryParse(personId, out var pid) ? pid : (int?)null;
            DateTime? parsedStart = DateTime.TryParse(startDate, out var sd) ? sd : (DateTime?)null;
            DateTime? parsedEnd = DateTime.TryParse(endDate, out var ed) ? ed : (DateTime?)null;
            ulong? parsedFrom = ulong.TryParse(fromId, out var fid) ? fid : (ulong?)null;

            return new JournalRequest
            {
                PersonId = parsedPerson,
                EventKinds = eventKinds,
                StartDate = parsedStart,
                EndDate = parsedEnd,
                FromId = parsedFrom,
                Count = count,
                ObjectTypesIds = objectTypesIds
            };
        }

        [NodeName("MakeAdminJournalRequest")]
        [IsDesignScriptCompatible]
        public static AdminJournalRequest MakeAdminJournalRequest(
            int count = 100,
            string fromId = null,
            string userName = null,
            string ip = null,
            string startDate = null,
            string endDate = null,
            AdminEventKind[] eventKinds = null)
        {
            ulong? parsedFrom = ulong.TryParse(fromId, out var fid) ? fid : (ulong?)null;
            DateTime? parsedStart = DateTime.TryParse(startDate, out var sd) ? sd : (DateTime?)null;
            DateTime? parsedEnd = DateTime.TryParse(endDate, out var ed) ? ed : (DateTime?)null;

            return new AdminJournalRequest
            {
                Count = count,
                FromId = parsedFrom,
                UserName = userName,
                Ip = ip,
                StartDate = parsedStart,
                EndDate = parsedEnd,
                EventKinds = eventKinds
            };
        }
    }
}

