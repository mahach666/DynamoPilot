using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;

namespace DataObject
{
    public static class Edit
    {
        [IsDesignScriptCompatible]
        public static PDataObject ChangeState(PDataObject @object, ObjectState state)
        {
            StaticMetadata.ObjectModifier.ChangeState((IDataObject)@object.Unwrap(), state);
            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();
            return Select.GetByGuid(@object.Id); 
        }
    }
}
