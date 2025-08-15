using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System;

namespace DataObject.Edit
{
    /// <summary>
    /// Ноды для различных операций редактирования объектов данных
    /// </summary>
    public class Other
    {
        /// <summary>
        /// Сохраняет элемент истории объекта
        /// </summary>
        /// <param name="objectId">Идентификатор объекта</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject SaveHistoryItem(Guid objectId)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SaveHistoryItem();

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Get.GetByGuid(objectId);
        }

        /// <summary>
        /// Сохраняет элемент истории объекта
        /// </summary>
        /// <param name="obj">Объект данных</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject SaveHistoryItemByObj(PDataObject obj)
        {
            return SaveHistoryItem(obj.Id);
        }

        /// <summary>
        /// Устанавливает дату создания объекта
        /// </summary>
        /// <param name="objectId">Идентификатор объекта</param>
        /// <param name="dateTime">Новая дата создания</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject SetCreationDate(Guid objectId, DateTime dateTime)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetCreationDate(dateTime);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Get.GetByGuid(objectId);
        }

        /// <summary>
        /// Устанавливает дату создания объекта
        /// </summary>
        /// <param name="obj">Объект данных</param>
        /// <param name="dateTime">Новая дата создания</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject SetCreationDateByObj(PDataObject obj, DateTime dateTime)
        {
            return SetCreationDate(obj.Id, dateTime);
        }

        /// <summary>
        /// Устанавливает создателя объекта
        /// </summary>
        /// <param name="objectId">Идентификатор объекта</param>
        /// <param name="creatorId">Идентификатор нового создателя</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject SetCreator(Guid objectId,
            int creatorId)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetCreator(creatorId);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Get.GetByGuid(objectId);
        }

        /// <summary>
        /// Устанавливает создателя объекта
        /// </summary>
        /// <param name="obj">Объект данных</param>
        /// <param name="creatorId">Идентификатор нового создателя</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject SetCreatorByObj(PDataObject obj,
            int creatorId)
        {
            return SetCreator(obj.Id, creatorId);
        }

        /// <summary>
        /// Устанавливает родительский объект
        /// </summary>
        /// <param name="objectId">Идентификатор объекта</param>
        /// <param name="parentId">Идентификатор нового родителя</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject SetParent(Guid objectId, Guid parentId)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetParent(parentId);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Get.GetByGuid(objectId);
        }

        /// <summary>
        /// Устанавливает родительский объект
        /// </summary>
        /// <param name="obj">Объект данных</param>
        /// <param name="parentId">Идентификатор нового родителя</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject SetParentByObj(PDataObject obj, Guid parentId)
        {
            return SetParent(obj.Id, parentId);
        }


        /// <summary>
        /// Устанавливает тип объекта
        /// </summary>
        /// <param name="objectId">Идентификатор объекта</param>
        /// <param name="type">Новый тип объекта</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject SetType(Guid objectId, IType type)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetType(type);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Get.GetByGuid(objectId);
        }

        /// <summary>
        /// Устанавливает тип объекта
        /// </summary>
        /// <param name="obj">Объект данных</param>
        /// <param name="type">Новый тип объекта</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject SetTypeByObj(PDataObject obj, IType type)
        {
            return SetType(obj.Id, type);
        }
    }
}
