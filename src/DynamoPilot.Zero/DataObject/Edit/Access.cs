using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System;

namespace DataObject.Edit
{
    /// <summary>
    /// Ноды для управления правами доступа к объектам данных
    /// </summary>
    public static class Access
    {
        /// <summary>
        /// Добавляет запись доступа к объекту
        /// </summary>
        /// <param name="objectId">Идентификатор объекта</param>
        /// <param name="orgUnitId">Идентификатор организационной единицы</param>
        /// <param name="level">Уровень доступа</param>
        /// <param name="validThrough">Дата окончания действия</param>
        /// <param name="inheritance">Наследование доступа</param>
        /// <param name="type">Тип доступа</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject AddAccessRecord(
            Guid objectId,
            int orgUnitId,
            AccessLevel level,
            DateTime validThrough,
            AccessInheritance inheritance,
            AccessType type)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).AddAccessRecords(orgUnitId,
                level,
                validThrough,
                inheritance,
                type);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Get.GetByGuid(objectId);
        }

        /// <summary>
        /// Добавляет запись доступа к объекту
        /// </summary>
        /// <param name="obj">Объект данных</param>
        /// <param name="orgUnitId">Идентификатор организационной единицы</param>
        /// <param name="level">Уровень доступа</param>
        /// <param name="validThrough">Дата окончания действия</param>
        /// <param name="inheritance">Наследование доступа</param>
        /// <param name="type">Тип доступа</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject AddAccessRecordByObj(
            PDataObject obj,
            int orgUnitId,
            AccessLevel level,
            DateTime validThrough,
            AccessInheritance inheritance,
            AccessType type)
        {
            return AddAccessRecord(obj.Id, orgUnitId, level, validThrough, inheritance, type);
        }

        /// <summary>
        /// Добавляет записи доступа к объекту для нескольких типов
        /// </summary>
        /// <param name="objectId">Идентификатор объекта</param>
        /// <param name="orgUnitId">Идентификатор организационной единицы</param>
        /// <param name="level">Уровень доступа</param>
        /// <param name="validThrough">Дата окончания действия</param>
        /// <param name="inheritance">Наследование доступа</param>
        /// <param name="type">Тип доступа</param>
        /// <param name="typeIds">Массив идентификаторов типов</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject AddAccessRecords(Guid objectId,
            int orgUnitId,
            AccessLevel level,
            DateTime validThrough,
            AccessInheritance inheritance,
            AccessType type,
            int[] typeIds)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).AddAccessRecords(orgUnitId,
                level,
                validThrough,
                inheritance,
                type,
                typeIds);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Get.GetByGuid(objectId);
        }

        /// <summary>
        /// Добавляет записи доступа к объекту для нескольких типов
        /// </summary>
        /// <param name="obj">Объект данных</param>
        /// <param name="orgUnitId">Идентификатор организационной единицы</param>
        /// <param name="level">Уровень доступа</param>
        /// <param name="validThrough">Дата окончания действия</param>
        /// <param name="inheritance">Наследование доступа</param>
        /// <param name="type">Тип доступа</param>
        /// <param name="typeIds">Массив идентификаторов типов</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject AddAccessRecordsByObj(
            PDataObject obj,
            int orgUnitId,
            AccessLevel level,
            DateTime validThrough,
            AccessInheritance inheritance,
            AccessType type,
            int[] typeIds)
        {
            return AddAccessRecords(obj.Id, orgUnitId, level, validThrough, inheritance, type, typeIds);
        }
    }
}
