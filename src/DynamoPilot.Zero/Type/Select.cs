using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System.Collections.Generic;
using System.Linq;

namespace Type
{
    public static class Select
    {
        [IsDesignScriptCompatible]
        public static List<PilotType> AllTypes()
        {
            var repo = StaticMetadata.ObjectsRepository;

            return repo?.GetTypes()
                .ToList()
                   ?? new List<PilotType>();
        }

        [IsDesignScriptCompatible]
        public static PilotType GetTypeById(int id)
            => StaticMetadata.ObjectsRepository?.GetType(id);

        [IsDesignScriptCompatible]
        public static PilotType GetTypeByName(string name)
            => StaticMetadata.ObjectsRepository?.GetType(name);
    }
}