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
    /// Управление счетчиками.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.Counters")]
    [NodeDescription("Получение и обновление счетчиков")]
    public static class Counters
    {
        [NodeName("GetCounters")]
        [IsDesignScriptCompatible]
        public static IEnumerable<DCounter> GetCounters(ServerSession session)
        {
            return SessionGuard.EnsureAdmin(session).GetCounters();
        }

        [NodeName("UpdateCounter")]
        [IsDesignScriptCompatible]
        public static void UpdateCounter(ServerSession session, DCounter counter)
        {
            SessionGuard.EnsureAdmin(session).UpdateCounter(counter);
        }

        [NodeName("DeleteCounter")]
        [IsDesignScriptCompatible]
        public static void DeleteCounter(ServerSession session, string counterName)
        {
            SessionGuard.EnsureAdmin(session).DeleteCounter(counterName);
        }
    }
}

