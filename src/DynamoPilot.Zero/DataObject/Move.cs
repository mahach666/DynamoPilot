using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System;

namespace DataObject
{
    public static class Move
    {
        [IsDesignScriptCompatible]
        public static bool MoveByObj(PDataObject @object, PDataObject newParent)
        {
            return MoveById(@object.Id, newParent.Id);
        }

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
