using System;
using System.Collections.Generic;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace ServerObject
{
    /// <summary>
    /// Узлы для получения объектов по идентификаторам.
    /// </summary>
    [NodeCategory("Pilot.Server.Object")]
    [NodeDescription("Получение объектов по GUID через серверное API")]
    public static class Get
    {
        [NodeName("GetObjects")]
        [IsDesignScriptCompatible]
        public static IList<DObject> GetObjects(ServerSession session, IList<string> ids)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            var guidIds = SessionGuard.ParseGuids(ids ?? Array.Empty<string>());
            return guidIds.Length == 0
                ? new List<DObject>()
                : srv.GetObjects(guidIds);
        }
    }
}

