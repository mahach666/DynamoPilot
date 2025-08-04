using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System;

namespace DataObject.Edit
{
    public static class Access
    {
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

            return Select.GetByGuid(objectId);
        }

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

            return Select.GetByGuid(objectId);
        }

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
