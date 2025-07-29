//using Dynamo.Graph.Nodes;
//using DynamoPilot.Data;
//using System.Collections.Generic;
//using System.Linq;

//namespace DynamoPilot.Nodes
//{
//    public static class PilotMetadata
//    {
//        [NodeName("Pilot Type Titles")]
//        [NodeCategory("Pilot.Metadata")]
//        [IsDesignScriptCompatible]
//        public static IList<string> TypeTitles()
//        {
//            var repo = StaticMetadata.ObjectsRepository;
//            return repo?.GetTypes().Select(t => t.Title).ToList()
//                   ?? new List<string>();
//        }
//    }
//}
