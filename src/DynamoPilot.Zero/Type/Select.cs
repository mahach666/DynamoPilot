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
        public static List<PType> AllTypes()
        {
            var repo = StaticMetadata.ObjectsRepository;

            return repo?.GetTypes()
                .ToList()
                   ?? new List<PType>();
        }

        [IsDesignScriptCompatible]
        public static PType GetTypeById(int id)
            => StaticMetadata.ObjectsRepository?.GetType(id);

        [IsDesignScriptCompatible]
        public static PType GetTypeByName(string name)
            => StaticMetadata.ObjectsRepository?.GetType(name);
    }
}