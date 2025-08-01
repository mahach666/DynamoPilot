using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;

namespace ObjectsRepository
{
    public static class Select
    {
        [IsDesignScriptCompatible]
        [NodeName("ObjectsRepository")]
        public static PObjectsRepository Get()
        {
            return StaticMetadata.ObjectsRepository;
        }
    }
}