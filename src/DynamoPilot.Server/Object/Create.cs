using System;
using System.Collections.Generic;
using System.Linq;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace ServerObject
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
            var srv = SessionGuard.EnsureSession(session).ServerApi;

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

            ApplyAttributes(newObj.Attributes, attributes);

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

            var srv = SessionGuard.EnsureSession(session).ServerApi;
            var id = Guid.Parse(objectId);
            var existing = srv.GetObjects(new[] { id }).FirstOrDefault()
                           ?? throw new InvalidOperationException("Объект не найден");

            var updated = existing.Clone();
            updated.Attributes = new Dictionary<string, DValue>(existing.Attributes);
            ApplyAttributes(updated.Attributes, attributes);

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

        private static void ApplyAttributes(IDictionary<string, DValue> target, IDictionary<string, object> attributes)
        {
            if (target == null || attributes == null)
                return;

            foreach (var kvp in attributes)
            {
                var name = kvp.Key;
                var value = kvp.Value;
                if (string.IsNullOrWhiteSpace(name) || value == null)
                    continue;

                target[name] = ToDValue(value);
            }
        }

        private static DValue ToDValue(object value)
        {
            return value switch
            {
                string s => new DValue { StrValue = s },
                int i => new DValue { IntValue = i },
                long l => new DValue { IntValue = l },
                double d => new DValue { DoubleValue = d },
                decimal dec => new DValue { DecimalValue = dec },
                DateTime dt => new DValue { DateValue = dt },
                Guid g => new DValue { GuidValue = g },
                int[] ia => new DValue { ArrayIntValue = ia },
                IEnumerable<int> ien => new DValue { ArrayIntValue = ien.ToArray() },
                string[] sa => new DValue { ArrayValue = sa },
                IEnumerable<string> se => new DValue { ArrayValue = se.ToArray() },
                _ => new DValue { StrValue = value.ToString() }
            };
        }
    }
}

