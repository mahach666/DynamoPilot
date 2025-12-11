using System.Collections.Generic;
using System.Linq;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace Admin.Journal
{
    /// <summary>
    /// Получение записей журналов действий (требует ServerAdminSession).
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.Journal")]
    [NodeDescription("Загрузка пользовательского и административного журнала")]
    public static class Get
    {
        [NodeName("GetJournalItems")]
        [IsDesignScriptCompatible]
        public static IList<DUserAction> GetJournalItems(ServerAdminSession session, JournalRequest request)
        {
            var srv = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            var effectiveRequest = request ?? new JournalRequest { Count = 100 };
            var items = srv.GetJournalItems(effectiveRequest);
            return items?.ToList() ?? new List<DUserAction>();
        }

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

