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
    /// Узлы для подготовки и применения changeset'ов создания объектов.
    /// </summary>
    [NodeCategory("Pilot.Server.Object.Create")]
    [NodeDescription("Создание объектов через серверное API (Change)")]
    public static class Create
    {
        [NodeName("BuildCreateChangeset")]
        [IsDesignScriptCompatible]
        public static DChangesetData BuildCreateChangeset(
            Guid id,
            int typeId,
            Guid parentId,
            IDictionary<string, DValue> attributes)
        {
            var changeset = new DChangesetData
            {
                Identity = Guid.NewGuid()
            };

            var newObj = new DObject
            {
                Id = id == Guid.Empty ? Guid.NewGuid() : id,
                TypeId = typeId,
                ParentId = parentId,
                Attributes = attributes != null
                    ? new Dictionary<string, DValue>(attributes)
                    : new Dictionary<string, DValue>(),
                Created = DateTime.UtcNow
            };

            var change = new DChange
            {
                New = newObj
            };

            changeset.Changes.Add(change);
            return changeset;
        }

        [NodeName("CreateObject")]
        [IsDesignScriptCompatible]
        public static DChangeset CreateObject(
            ServerSession session,
            Guid id,
            int typeId,
            Guid parentId,
            IDictionary<string, DValue> attributes)
        {
            var changeset = BuildCreateChangeset(id, typeId, parentId, attributes);
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            return srv.Change(changeset);
        }
    }
}

