using Ascon.Pilot.SDK;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using System;

namespace Utils
{
    public static class Parsers
    {
        [IsDesignScriptCompatible]
        [IsVisibleInDynamoLibrary(false)]
        public static ObjectState ParseObjectState(string stateString)
        {
            if (Enum.TryParse<ObjectState>(stateString, out var result))
            {
                return result;
            }
            return ObjectState.Alive;
        }

        [IsDesignScriptCompatible]
        [IsVisibleInDynamoLibrary(false)]
        public static SearchMode ParseSearchMode(string stateString)
        {
            if (Enum.TryParse<SearchMode>(stateString, out var result))
            {
                return result;
            }
            return SearchMode.Files;
        }

        [IsDesignScriptCompatible]
        [IsVisibleInDynamoLibrary(false)]
        public static ObjectRelationType ParseRelationType(string stateString)
        {
            if (Enum.TryParse<ObjectRelationType>(stateString, out var result))
            {
                return result;
            }
            return ObjectRelationType.Custom;
        }
    }
}
