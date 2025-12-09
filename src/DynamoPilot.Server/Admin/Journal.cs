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
            int? personId = null,
            EventKind[] eventKinds = null,
            DateTime? startDate = null,
            DateTime? endDate = null,
            ulong? fromId = null,
            int count = 100,
            int[] objectTypesIds = null)
        {
            return new JournalRequest
            {
                PersonId = personId,
                EventKinds = eventKinds,
                StartDate = startDate,
                EndDate = endDate,
                FromId = fromId,
                Count = count,
                ObjectTypesIds = objectTypesIds
            };
        }

        [NodeName("MakeAdminJournalRequest")]
        [IsDesignScriptCompatible]
        public static AdminJournalRequest MakeAdminJournalRequest(
            int count = 100,
            ulong? fromId = null,
            string userName = null,
            string ip = null,
            DateTime? startDate = null,
            DateTime? endDate = null,
            AdminEventKind[] eventKinds = null)
        {
            return new AdminJournalRequest
            {
                Count = count,
                FromId = fromId,
                UserName = userName,
                Ip = ip,
                StartDate = startDate,
                EndDate = endDate,
                EventKinds = eventKinds
            };
        }
    }
}

