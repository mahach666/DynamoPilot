using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.App.Utils;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System;
using System.Collections.Generic;
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

        [IsDesignScriptCompatible]
        public static PDataObject GetParentByTypeId(PDataObject pDataObject, int id)
        {
            var context = pDataObject.Context();
            var loader = new SynkObjectLoader((IObjectsRepository)StaticMetadata.ObjectsRepository.Unwrap());

            return loader.LoadObjects(context, default)
                .Where(o => o.Type.Id == id && o.Id != pDataObject.Id)
                .Select(o => new PDataObject(o))
                .FirstOrDefault();
        }

        [IsDesignScriptCompatible]
        public static PDataObject GetParentByTypeName(PDataObject pDataObject, string name)
        {
            var context = pDataObject.Context();
            var loader = new SynkObjectLoader((IObjectsRepository)StaticMetadata.ObjectsRepository.Unwrap());

            return loader.LoadObjects(context, default)
                .Where(o => o.Type.Name == name && o.Id != pDataObject.Id)
                .Select(o => new PDataObject(o))
                .FirstOrDefault();
        }

        [IsDesignScriptCompatible]
        public static List<PDataObject> GetParentListByTypeId(PDataObject pDataObject, int id)
        {
            var context = pDataObject.Context();
            var loader = new SynkObjectLoader((IObjectsRepository)StaticMetadata.ObjectsRepository.Unwrap());

            return loader.LoadObjects(context, default)
                .Where(o => o.Type.Id == id && o.Id != pDataObject.Id)
                .Select(o => new PDataObject(o))
                .ToList();
        }

        [IsDesignScriptCompatible]
        public static List<PDataObject> GetParentListByTypeName(PDataObject pDataObject, string name)
        {
            var context = pDataObject.Context();
            var loader = new SynkObjectLoader((IObjectsRepository)StaticMetadata.ObjectsRepository.Unwrap());

            return loader.LoadObjects(context, default)
                .Where(o => o.Type.Name == name && o.Id != pDataObject.Id)
                .Select(o => new PDataObject(o))
                .ToList();
        }
    }
}