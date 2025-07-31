using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System.Threading.Tasks;

namespace ObjectsRepository
{
    public static class Select
    {
        [IsDesignScriptCompatible]
        public static PilotObjectsRepository ObjectsRepository()
        {
            return StaticMetadata.ObjectsRepository;
        }

        [IsDesignScriptCompatible]
        public static PilotDataObject GetObj(string id)
        {
            return StaticMetadata.ObjectsRepository.GetObject(id);
        }
    }
}