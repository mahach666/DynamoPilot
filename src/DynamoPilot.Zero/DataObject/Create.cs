using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataObject
{
    /// <summary>
    /// Ноды для создания объектов данных в системе Pilot
    /// </summary>
    public static class Create
    {
        /// <summary>
        /// Создает новый объект данных с указанным родительским объектом и типом
        /// </summary>
        /// <param name="parent">Родительский объект данных</param>
        /// <param name="type">Тип создаваемого объекта</param>
        /// <returns>Созданный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject CreateByParentObjAndType(PDataObject parent, PType type)
        {
            var builder = StaticMetadata.ObjectModifier.Create((IDataObject)parent.Unwrap(), (IType)type.Unwrap());
            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();
            return Get.GetByGuid(builder.DataObject.Id);
        }

        /// <summary>
        /// Создает новый объект данных с указанным идентификатором, родительским объектом и типом
        /// </summary>
        /// <param name="id">Уникальный идентификатор создаваемого объекта</param>
        /// <param name="parent">Родительский объект данных</param>
        /// <param name="type">Тип создаваемого объекта</param>
        /// <returns>Созданный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject CreateByIdAndParentObjAndType(Guid id, PDataObject parent, PType type)
        {
            var builder = StaticMetadata.ObjectModifier.Create(id, (IDataObject)parent.Unwrap(), (IType)type.Unwrap());
            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();
            return Get.GetByGuid(builder.DataObject.Id);
        }

        /// <summary>
        /// Создает новый объект данных с указанным идентификатором родителя и типом
        /// </summary>
        /// <param name="parentId">Идентификатор родительского объекта</param>
        /// <param name="type">Тип создаваемого объекта</param>
        /// <returns>Созданный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject CreateByParentIdAndType(Guid parentId, PType type)
        {
            var builder = StaticMetadata.ObjectModifier.Create(parentId, (IType)type.Unwrap());
            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();
            return Get.GetByGuid(builder.DataObject.Id);
        }

        /// <summary>
        /// Создает новый объект данных с указанными идентификаторами объекта, родителя и типом
        /// </summary>
        /// <param name="id">Уникальный идентификатор создаваемого объекта</param>
        /// <param name="parentId">Идентификатор родительского объекта</param>
        /// <param name="type">Тип создаваемого объекта</param>
        /// <returns>Созданный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject CreateByIdAndParentIdAndType(Guid id, Guid parentId, PType type)
        {
            var builder = StaticMetadata.ObjectModifier.CreateById(id, parentId, (IType)type.Unwrap());
            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();
            return Get.GetByGuid(builder.DataObject.Id);
        }

        /// <summary>
        /// Создает объект и сразу заполняет атрибуты (словарь ключ-значение).
        /// </summary>
        /// <param name="parent">Родительский объект</param>
        /// <param name="type">Тип создаваемого объекта</param>
        /// <param name="attributes">Словарь атрибутов (имя -> значение)</param>
        [IsDesignScriptCompatible]
        public static PDataObject CreateWithAttributes(PDataObject parent, PType type, Dictionary<string, object> attributes)
        {
            var builder = StaticMetadata.ObjectModifier.Create((IDataObject)parent.Unwrap(), (IType)type.Unwrap());
            ApplyAttributes(builder, attributes);
            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();
            return Get.GetByGuid(builder.DataObject.Id);
        }

        /// <summary>
        /// Создает объект с заданным Guid и заполняет атрибуты.
        /// </summary>
        /// <param name="id">Идентификатор создаваемого объекта</param>
        /// <param name="parentId">Идентификатор родителя</param>
        /// <param name="type">Тип создаваемого объекта</param>
        /// <param name="attributes">Словарь атрибутов (имя -> значение)</param>
        [IsDesignScriptCompatible]
        public static PDataObject CreateWithIdAndAttributes(Guid id, Guid parentId, PType type, IDictionary<string, object> attributes)
        {
            var builder = StaticMetadata.ObjectModifier.CreateById(id, parentId, (IType)type.Unwrap());
            ApplyAttributes(builder, attributes);
            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();
            return Get.GetByGuid(builder.DataObject.Id);
        }

        private static void ApplyAttributes(PObjectBuilder builder, IDictionary<string, object> attributes)
        {
            if (builder == null || attributes == null)
                return;

            foreach (var kvp in attributes)
            {
                builder.SetAttributeAsObject(kvp.Key,kvp.Value);
            }
        }
    }
}
