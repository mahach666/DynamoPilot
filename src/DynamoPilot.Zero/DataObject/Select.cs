using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.App.Utils;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System;
using System.Linq;
using System.Reactive.Linq;

namespace DataObject
{
    public static class Select
    {
        [IsDesignScriptCompatible]
        public static PDataObject GetByGuid(Guid id)
        {
            var loader = new SynkObjectLoader((IObjectsRepository)StaticMetadata.ObjectsRepository.Unwrap());

            var preRes = loader.LoadObjects(new[] { id }, default).FirstOrDefault();
            if (preRes == null) return null;

            return new PDataObject(preRes);
        }

        [IsDesignScriptCompatible]
        public static PDataObject GetByStrGuid(string id)
        {
            return GetByGuid(new Guid(id));
        }
    }
}