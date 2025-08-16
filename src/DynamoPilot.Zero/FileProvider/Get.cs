using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;

namespace FileProvider
{
    public static class Get
    {
        [IsDesignScriptCompatible]
        public static PFileProvider GetFileProvider()
        {
            return StaticMetadata.FileProvider;
        }
    }
}
