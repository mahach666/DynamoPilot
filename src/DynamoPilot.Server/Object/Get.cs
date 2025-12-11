using System;
using System.Collections.Generic;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;
using System.Linq;

namespace SObject
{
    /// <summary>
    /// Результат получения объекта с правами.
    /// </summary>
    [IsVisibleInDynamoLibrary(false)]
    public class ObjectWithRights
    {
        public DObject Obj { get; set; }
        public AccessLevel Level { get; set; }
        public IList<int> Subtypes { get; set; }
    }

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

        /// <summary>
        /// Возвращает объекты с правами доступа и подтипами.
        /// </summary>
        [NodeName("GetObjectsWithRights")]
        [IsDesignScriptCompatible]
        public static IList<ObjectWithRights> GetObjectsWithRights(ServerSession session, IList<string> ids)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            var guidIds = SessionGuard.ParseGuids(ids ?? Array.Empty<string>());
            if (guidIds.Length == 0)
                return new List<ObjectWithRights>();

            var result = srv.GetObjectsWithRights(guidIds);
            return result?
                .Select(r => new ObjectWithRights
                {
                    Obj = r.obj,
                    Level = r.level,
                    Subtypes = r.subtypes ?? new List<int>()
                })
                .ToList() ?? new List<ObjectWithRights>();
        }
    }
}

