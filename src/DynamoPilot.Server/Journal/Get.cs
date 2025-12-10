using System.Collections.Generic;
using System.Linq;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace ServerJournal
{
    /// <summary>
    /// Узлы для получения записей журналов действий.
    /// </summary>
    [NodeCategory("Pilot.Server.Journal")]
    [NodeDescription("Загрузка записей пользовательского и административного журнала")]
    public static class Get
    {
        /// <summary>
        /// Возвращает записи пользовательского журнала.
        /// </summary>
        [NodeName("GetJournalItems")]
        [IsDesignScriptCompatible]
        public static IList<DUserAction> GetJournalItems(ServerAdminSession session, JournalRequest request)
        {
            var srv = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            var effectiveRequest = request ?? new JournalRequest { Count = 100 };
            var items = srv.GetJournalItems(effectiveRequest);
            return items?.ToList() ?? new List<DUserAction>();
        }

        /// <summary>
        /// Возвращает записи административного журнала.
        /// </summary>
        [NodeName("GetAdminJournalItems")]
        [IsDesignScriptCompatible]
        public static IList<DAdminAction> GetAdminJournalItems(ServerAdminSession session, AdminJournalRequest request)
        {
            var srv = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            var effectiveRequest = request ?? new AdminJournalRequest { Count = 100 };
            var items = srv.GetAdminJournalItems(effectiveRequest);
            return items?.ToList() ?? new List<DAdminAction>();
        }
    }
}

