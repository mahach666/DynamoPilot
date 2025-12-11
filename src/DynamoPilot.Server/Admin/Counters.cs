using System.Collections.Generic;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;
using System.Linq;

namespace ServerAdminCounters
{
    /// <summary>
    /// Работа со счетчиками.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.Counters")]
    [NodeDescription("Получение и изменение счетчиков через ServerAdminApi")]
    public static class Counters
    {
        [NodeName("GetCounters")]
        [IsDesignScriptCompatible]
        public static IList<DCounter> GetCounters(ServerAdminSession session)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.GetCounters()?.ToList() ?? new List<DCounter>();
        }

        [NodeName("UpdateCounter")]
        [IsDesignScriptCompatible]
        public static void UpdateCounter(ServerAdminSession session, DCounter counter)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.UpdateCounter(counter);
        }

        [NodeName("DeleteCounter")]
        [IsDesignScriptCompatible]
        public static void DeleteCounter(ServerAdminSession session, string counterName)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.DeleteCounter(counterName);
        }
    }
}

