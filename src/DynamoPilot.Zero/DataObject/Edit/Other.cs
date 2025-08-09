using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System;

namespace DataObject.Edit
{
    public class Other
    {
        [IsDesignScriptCompatible]
        public static PDataObject SaveHistoryItem(Guid objectId)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SaveHistoryItem();

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject SetCreationDate(Guid objectId, DateTime dateTime)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetCreationDate(dateTime);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject SetCreator(Guid objectId,
            int creatorId)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetCreator(creatorId);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject SetParent(Guid objectId, Guid parentId)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetParent(parentId);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }


        [IsDesignScriptCompatible]
        public static PDataObject SetType(Guid objectId, IType type)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetType(type);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }
    }
}
