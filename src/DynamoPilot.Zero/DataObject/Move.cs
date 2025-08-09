using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System;

namespace DataObject
{
    /// <summary>
    /// Ноды для перемещения объектов данных в системе Pilot
    /// </summary>
    public static class Move
    {
        /// <summary>
        /// Перемещает объект к новому родителю
        /// </summary>
        /// <param name="object">Перемещаемый объект</param>
        /// <param name="newParent">Новый родительский объект</param>
        /// <returns>True, если перемещение прошло успешно</returns>
        [IsDesignScriptCompatible]
        public static bool MoveByObj(PDataObject @object, PDataObject newParent)
        {
            return MoveById(@object.Id, newParent.Id);
        }

        /// <summary>
        /// Перемещает объект по идентификаторам к новому родителю
        /// </summary>
        /// <param name="objectId">Идентификатор перемещаемого объекта</param>
        /// <param name="newParentId">Идентификатор нового родителя</param>
        /// <returns>True, если перемещение прошло успешно</returns>
        public static bool MoveById(Guid objectId, Guid newParentId)
        {
            try
            {
                StaticMetadata.ObjectModifier.MoveById(objectId, newParentId);
                StaticMetadata.ObjectModifier.Apply();
                StaticMetadata.ObjectModifier.Clear();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
