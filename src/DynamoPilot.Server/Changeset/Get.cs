using System.Collections.Generic;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace SChangeset
{
    /// <summary>
    /// Узлы для получения и применения изменений.
    /// </summary>
    [NodeCategory("Pilot.Server.Changeset")]
    [NodeDescription("Работа с изменениями и историей через серверное API")]
    public static class Get
    {
        [NodeName("GetChangesets")]
        [IsDesignScriptCompatible]
        public static IList<DChangeset> GetChangesets(ServerSession session, long first, long last)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            return srv.GetChangesets(first, last);
        }

        [NodeName("ApplyChanges")]
        [IsDesignScriptCompatible]
        public static DChangeset ApplyChanges(ServerSession session, DChangesetData changes)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            return srv.Change(changes);
        }

        /// <summary>
        /// Асинхронная отправка изменений (fire-and-forget).
        /// </summary>
        [NodeName("ApplyChangesAsync")]
        [IsDesignScriptCompatible]
        public static void ApplyChangesAsync(ServerSession session, DChangesetData changes)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            srv.ChangeAsync(changes);
        }
    }
}

