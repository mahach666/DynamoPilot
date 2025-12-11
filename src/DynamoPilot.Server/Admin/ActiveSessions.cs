using System.Collections.Generic;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;
using System.Linq;

namespace ServerAdminActiveSessions
{
    /// <summary>
    /// Получение активных сессий.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.ActiveSessions")]
    [NodeDescription("Активные сессии пользователей через ServerAdminApi")]
    public static class ActiveSessions
    {
        [NodeName("GetActiveSessions")]
        [IsDesignScriptCompatible]
        public static IList<DActiveSession> GetActiveSessions(ServerAdminSession session)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.GetActiveSessions()?.ToList() ?? new List<DActiveSession>();
        }

        [NodeName("GetActiveSessionsByProduct")]
        [IsDesignScriptCompatible]
        public static IList<DActiveSession> GetActiveSessions(ServerAdminSession session, int productId)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.GetActiveSessions(productId)?.ToList() ?? new List<DActiveSession>();
        }
    }
}

