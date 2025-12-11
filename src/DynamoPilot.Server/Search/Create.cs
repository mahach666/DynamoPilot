using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;
using System;

namespace SSearch
{
    /// <summary>
    /// Узлы для регистрации поисковых запросов.
    /// </summary>
    [NodeCategory("Pilot.Server.Search")]
    [NodeDescription("Добавление и удаление поисковых условий на сервере")]
    public static class Create
    {
        [NodeName("AddSearch")]
        [IsDesignScriptCompatible]
        public static void AddSearch(ServerSession session, DSearchDefinition searchDefinition)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            srv.AddSearch(searchDefinition);
        }

        [NodeName("RemoveSearch")]
        [IsDesignScriptCompatible]
        public static void RemoveSearch(ServerSession session, string definitionId)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            if (Guid.TryParse(definitionId, out var id))
                srv.RemoveSearch(id);
        }
    }
}

