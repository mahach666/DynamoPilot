using System;
using System.Collections.Generic;
using System.Linq;
using Ascon.Pilot.DataClasses;
using Ascon.Pilot.Server.Api.Contracts;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace ServerAdmin
{
    /// <summary>
    /// Управление активными сессиями.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.Sessions")]
    [NodeDescription("Получение и завершение сессий")]
    public static class Sessions
    {
        [NodeName("GetActiveSessions")]
        [IsDesignScriptCompatible]
        public static List<DActiveSession> GetActiveSessions(ServerSession session)
        {
            return SessionGuard.EnsureAdmin(session).GetActiveSessions().ToList();
        }

        [NodeName("GetActiveSessionsByProduct")]
        [IsDesignScriptCompatible]
        public static List<DActiveSession> GetActiveSessions(ServerSession session, int productId)
        {
            return SessionGuard.EnsureAdmin(session).GetActiveSessions(productId).ToList();
        }

        [NodeName("ReleaseSession")]
        [IsDesignScriptCompatible]
        public static void ReleaseSession(ServerSession session, Guid sessionId)
        {
            SessionGuard.EnsureAdmin(session).ReleaseSession(sessionId);
        }
    }
}

