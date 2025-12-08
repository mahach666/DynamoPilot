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
            Guid targetId)
        {
            var relationId = new Guid();
            var relation1 = new Ascon.Pilot.SDK.Relation
            {
                Id = relationId,
                Type = type,
                Name = name,
                TargetId = objectId
            };
            var relation2 = new Ascon.Pilot.SDK.Relation
            {
                Id = relationId,
                Type = type,
                Name = name,
                TargetId = targetId
            };
            StaticMetadata.ObjectModifier.CreateLink(relation1, relation2);
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
            Guid targetId)
        {
            return AddRelation(obj.Id,
                name,
                type,
                targetId);
        }
    }
}
