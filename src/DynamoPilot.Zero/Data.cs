using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System.Collections.Generic;
using System.Linq;


public static class Data
{
    [NodeName("Pilot All Types")]
    [IsDesignScriptCompatible]
    public static List<PilotType> AllTypes()
    {
        var repo = StaticMetadata.ObjectsRepository;

        return repo?.GetTypes()
            .ToList()
               ?? new List<PilotType>();
    }
}

