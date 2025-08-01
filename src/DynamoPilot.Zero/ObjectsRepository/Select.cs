using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;

namespace ObjectsRepository
{
    public static class Select
    {
        [IsDesignScriptCompatible]
        public static PilotObjectsRepository Get()
        {
            return StaticMetadata.ObjectsRepository;
        }
    }
}