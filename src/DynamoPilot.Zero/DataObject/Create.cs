using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System;

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
    }
}
