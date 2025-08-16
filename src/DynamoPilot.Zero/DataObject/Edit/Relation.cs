using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System;

namespace DataObject.Edit
{
    /// <summary>
    /// Ноды для добавления связей к объектам данных
    /// </summary>
    public static class Relation
    {
        /// <summary>
        /// Добавляет связь к объекту данных по идентификатору объекта
        /// </summary>
        /// <param name="objectId">Идентификатор объекта</param>
        /// <param name="name">Имя связи</param>
        /// <param name="type">Тип связи</param>
        /// <param name="sourceId">Идентификатор исходного объекта</param>
        /// <param name="targetId">Идентификатор целевого объекта</param>
        /// <param name="versionId">Идентификатор версии (дата/время)</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject AddRelation(
            Guid objectId,
            string name,
            ObjectRelationType type,
            Guid sourceId,
            Guid targetId,
            DateTime versionId)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).AddRelation(name,
                type,
                sourceId,
                targetId,
                versionId);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Get.GetByGuid(objectId);
        }

        /// <summary>
        /// Добавляет связь к объекту данных
        /// </summary>
        /// <param name="obj">Объект данных</param>
        /// <param name="name">Имя связи</param>
        /// <param name="type">Тип связи</param>
        /// <param name="sourceId">Идентификатор исходного объекта</param>
        /// <param name="targetId">Идентификатор целевого объекта</param>
        /// <param name="versionId">Идентификатор версии (дата/время)</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject AddRelationByObj(
            PDataObject obj,
            string name,
            ObjectRelationType type,
            Guid sourceId,
            Guid targetId,
            DateTime versionId)
        {
            return AddRelation(obj.Id,
                name,
                type,
                sourceId,
                targetId,
                versionId);
        }
    }
}
