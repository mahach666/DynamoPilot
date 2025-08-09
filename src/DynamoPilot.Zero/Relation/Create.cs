using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System;
using System.Collections.Generic;

namespace Relation
{
    /// <summary>
    /// Ноды для создания связей между объектами в системе Pilot
    /// </summary>
    public static class Create
    {
        /// <summary>
        /// Создает связь по идентификатору целевого объекта
        /// </summary>
        /// <param name="relationId">Идентификатор связи</param>
        /// <param name="relationType">Тип связи</param>
        /// <param name="relationName">Имя связи</param>
        /// <param name="targetId">Идентификатор целевого объекта</param>
        /// <returns>Созданная связь</returns>
        [IsDesignScriptCompatible]
        public static PRelation CreateByTargetId(Guid relationId,
            ObjectRelationType relationType,
            string relationName,
            Guid targetId)
        {
            var relation = new Ascon.Pilot.SDK.Relation
            {
                Id = relationId,
                Type = relationType,
                Name = relationName,
                TargetId = targetId
            };

            return new PRelation(relation);
        }

        [IsDesignScriptCompatible]
        public static PRelation CreateByTargetObj(Guid relationId,
            ObjectRelationType relationType,
            string relationName,
            PDataObject targetObj)
        {
            return CreateByTargetId(relationId, relationType, relationName, targetObj.Id);
        }

        public static List<PRelation> CreateCoupleByTargetIds(Guid relationId,
            ObjectRelationType relationType,
            string relationName,
            Guid targetId1,
            Guid targetId2)
        {
            var relation1 = new Ascon.Pilot.SDK.Relation
            {
                Id = relationId,
                Type = relationType,
                Name = relationName,
                TargetId = targetId1
            };
            var relation2 = new Ascon.Pilot.SDK.Relation
            {
                Id = relationId,
                Type = relationType,
                Name = relationName,
                TargetId = targetId2
            };

            return new List<PRelation>() { new(relation1), new(relation2) };
        }

        public static List<PRelation> CreateCoupleByTargetObjss(
            Guid relationId,
            ObjectRelationType relationType,
            string relationName,
            PDataObject targetObj1,
            PDataObject targetObj2)
        {
            return CreateCoupleByTargetIds(relationId,
             relationType,
             relationName,
             targetObj1.Id,
             targetObj2.Id);
        }

        [IsDesignScriptCompatible]
        public static void CreateLink(PRelation relation1, PRelation relation2)
        {
            StaticMetadata.ObjectModifier.CreateLink((IRelation)relation1.Unwrap(), (IRelation)relation2.Unwrap());
            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();
        }
    }
}
