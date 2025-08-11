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
