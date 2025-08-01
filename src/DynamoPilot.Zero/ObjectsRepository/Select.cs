using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.App.Utils;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System;
using System.Linq;
using System.Reactive.Linq;

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
            var loader = new SynkObjectLoader((IObjectsRepository)StaticMetadata.ObjectsRepository.Unwrap());

            var preRes = loader.LoadObjects(new[] { new Guid(id) }, default).FirstOrDefault();
            if (preRes == null) return null;

            return new PilotDataObject(preRes);
        }
    }
}