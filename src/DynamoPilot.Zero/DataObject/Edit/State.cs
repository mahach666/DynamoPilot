using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System;

namespace DataObject.Edit
{
    public class State
    {
        [IsDesignScriptCompatible]
        public static PDataObject ChangeState(PDataObject @object, ObjectState state)
        {
            StaticMetadata.ObjectModifier.ChangeState((IDataObject)@object.Unwrap(), state);
            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();
            return Select.GetByGuid(@object.Id);
        }

        [IsDesignScriptCompatible]
        public static PDataObject Lock(Guid objectId)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).Lock();

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject MakePublic(Guid objectId)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).MakePublic();

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject MakeSecret(Guid objectId)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).MakeSecret();

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject SetIsDeleted(Guid objectId,
            bool isDeleted)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetIsDeleted(isDeleted);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject SetIsInRecycleBin(Guid objectId,
            bool isInRecycleBin)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetIsInRecycleBin(isInRecycleBin);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject Unlock(Guid objectId)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).Unlock();

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }
    }
}
