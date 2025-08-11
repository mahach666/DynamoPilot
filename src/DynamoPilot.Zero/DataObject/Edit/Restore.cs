using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System;

namespace DataObject.Edit
{
    /// <summary>
    /// Ноды для восстановления объектов данных в системе Pilot
    /// </summary>
    public static class Restore
    {
        [IsDesignScriptCompatible]
        public static PDataObject RestoreById(Guid objectId, Guid parentId)
        {
            StaticMetadata.ObjectModifier.Restore(objectId, parentId);
            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();
            return Get.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject RestoreByObj(PDataObject obj, Guid parentId)
        {
            StaticMetadata.ObjectModifier.Restore(obj.Id, parentId);
            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();
            return Get.GetByGuid(obj.Id);
        }

        [IsDesignScriptCompatible]
        public static PDataObject RestorePermanentlyDeletedObject(Guid id, Guid parentId, IType type)
        {
            StaticMetadata.ObjectModifier.RestorePermanentlyDeletedObject(id, parentId, type);
            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();
            return Get.GetByGuid(id);
        }
    }
}