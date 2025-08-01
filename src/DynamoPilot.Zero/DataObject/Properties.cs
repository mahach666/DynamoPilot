using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System;


namespace DataObject
{
    public static class Properties
    {
        [IsDesignScriptCompatible]
        public static Guid GetId(PilotDataObject dataObject)
        {
            return dataObject.Id;
        }


    }
}

