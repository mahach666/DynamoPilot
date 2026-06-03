using System;
using System.Collections.Generic;
using System.Linq;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace SObject
{
    /// <summary>
    /// Узлы для создания и обновления объектов через ServerApi с заполнением атрибутов.
    /// </summary>
    [NodeCategory("Pilot.Server.Object")]
    [NodeDescription("Создание и обновление объектов с атрибутами через ServerApi")]
    public static class Create
    {
        /// <summary>
        /// Создает объект, заполняет атрибуты и применяет изменения.
        /// </summary>
        [NodeName("CreateObjectWithAttributes")]
        [IsDesignScriptCompatible]
        public static DObject CreateObjectWithAttributes(
            ServerSession session,
            string parentId,
            int typeId,
            IDictionary<string, object> attributes = null,
            string objectId = null)
        {
            var ensured = SessionGuard.EnsureSession(session);
            var srv = ensured.ServerApi;

            var parentGuid = Guid.Parse(parentId);
            var newId = string.IsNullOrWhiteSpace(objectId) ? Guid.NewGuid() : Guid.Parse(objectId);

            var newObj = new DObject
            {
                Id = newId,
                ParentId = parentGuid,
                TypeId = typeId,
                Created = DateTime.UtcNow,
                Attributes = new Dictionary<string, DValue>()
            };

            ServerAttributeConverter.Apply(newObj.Attributes, attributes, GetAttrTypeMap(ensured, typeId));

            var change = new DChange { New = newObj };
            var changeset = new DChangesetData
            {
                Identity = Guid.NewGuid(),
                Created = DateTime.UtcNow
            };
            changeset.Changes.Add(change);

            srv.Change(changeset);
            return srv.GetObjects(new[] { newId }).FirstOrDefault() ?? newObj;
        }

        /// <summary>
        /// Обновляет атрибуты существующего объекта (добавление/замена по имени).
        /// </summary>
        [NodeName("UpdateObjectAttributes")]
        [IsDesignScriptCompatible]
        public static DObject UpdateObjectAttributes(
            ServerSession session,
            string objectId,
            IDictionary<string, object> attributes)
        {
            if (attributes == null || attributes.Count == 0)
                throw new ArgumentException("Не переданы атрибуты для обновления", nameof(attributes));

            var ensured = SessionGuard.EnsureSession(session);
            var srv = ensured.ServerApi;
            var id = Guid.Parse(objectId);
            var existing = srv.GetObjects(new[] { id }).FirstOrDefault()
                           ?? throw new InvalidOperationException("Объект не найден");

            var updated = existing.Clone();
            updated.Attributes = new Dictionary<string, DValue>(existing.Attributes);
            ServerAttributeConverter.Apply(updated.Attributes, attributes, GetAttrTypeMap(ensured, existing.TypeId));

            var change = new DChange
            {
                Old = existing,
                New = updated
            };

            var changeset = new DChangesetData
            {
                Identity = Guid.NewGuid(),
                Created = DateTime.UtcNow
            };
            changeset.Changes.Add(change);

            srv.Change(changeset);
            return srv.GetObjects(new[] { id }).FirstOrDefault() ?? updated;
        }

        /// <summary>
        /// Строит карту «имя атрибута → тип» из метаданных базы для указанного типа объекта.
        /// Метаданные кэшируются в сессии. Возвращает null, если тип/метаданные недоступны
        /// (тогда применяется приведение по форме значения).
        /// </summary>
        private static IDictionary<string, MAttrType> GetAttrTypeMap(ServerSession ensured, int typeId)
        {
            try
            {
                var meta = ensured.Metadata;
                if (meta == null)
                {
                    meta = ensured.ServerApi.GetMetadata(0);
                    ensured.Metadata = meta;
                }

                var mType = meta?.Types?.FirstOrDefault(t => t.Id == typeId);
                if (mType?.Attributes == null) return null;

                var map = new Dictionary<string, MAttrType>(StringComparer.Ordinal);
                foreach (var a in mType.Attributes)
                    if (a != null && !string.IsNullOrEmpty(a.Name))
                        map[a.Name] = a.Type;
                return map;
            }
            catch
            {
                return null;
            }
        }
    }
}
