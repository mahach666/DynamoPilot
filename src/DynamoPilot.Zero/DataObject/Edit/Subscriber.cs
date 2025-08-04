using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System;

namespace DataObject.Edit
{
    public static class Subscriber
    {
        [IsDesignScriptCompatible]
        public static PDataObject AddSubscriber(
            Guid objectId,
            int personId)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).AddSubscriber(personId);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject AddSubscriberByObj(
            PDataObject obj,
            int personId)
        {
            return AddSubscriber(obj.Id, personId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject RemoveSubscriber(Guid objectId, int personId)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).RemoveSubscriber(personId);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject RemoveSubscriberByObj(PDataObject obj, int personId)
        {
            return RemoveSubscriber(obj.Id, personId);
        }
    }
}
