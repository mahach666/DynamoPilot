using Dynamo.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;

namespace DynamoPilot.App.Configuration
{
    [Export(typeof(IPathResolver))]
    class PilotPathResolver : IPathResolver
    {
        private readonly string baseDir;
        public PilotPathResolver(string pkgsDir) => baseDir = pkgsDir;

        public IEnumerable<string> PackageDirectories => new string[] 
        { 
            //baseDir,
            //Path.Combine(baseDir, "packages"),
            //Path.Combine(baseDir, "packages\\DynamoPilot"),
            //Path.Combine(baseDir, "packages\\DynamoPilot\\bin"),
            //Path.Combine(baseDir, "DynamoFeatureFlags"),
            //Path.Combine(baseDir, "extensions"),
            //Path.Combine(baseDir, "nodes") 
        };

    public IEnumerable<string> AdditionalResolutionPaths => new string[]
        {
        //    baseDir,
        //    Path.Combine(baseDir, "packages"),
        //    Path.Combine(baseDir, "packages\\DynamoPilot"),
        //    Path.Combine(baseDir, "packages\\DynamoPilot\\bin"),
        //    Path.Combine(baseDir, "DynamoFeatureFlags"),
        //    Path.Combine(baseDir, "extensions"),
        //    Path.Combine(baseDir, "nodes")
        };

        public IEnumerable<string> AdditionalNodeDirectories => new string[]
        { 
            //baseDir,
            //Path.Combine(baseDir, "packages"),
            //Path.Combine(baseDir, "packages\\DynamoPilot"),
            //Path.Combine(baseDir, "packages\\DynamoPilot\\bin"),
            //Path.Combine(baseDir, "DynamoFeatureFlags"),
            //Path.Combine(baseDir, "extensions"),
            //Path.Combine(baseDir, "nodes") 
        };
        public IEnumerable<string> PreloadedLibraryPaths =>  new string[] { Path.Combine(baseDir, "DSCoreNodes.dll"),
        Path.Combine(baseDir, "DSCoreNodes.customization.dll"),
        Path.Combine(baseDir, "DesignScriptBuiltin.dll"),
        Path.Combine(baseDir, "BuiltIn.customization.dll"),

        Path.Combine(baseDir, "CoreNodeModelsWpf.dll"),

        Path.Combine(baseDir, "DSCPython.dll"),
        Path.Combine(baseDir, "DSOffice.dll"),
        Path.Combine(baseDir, "DynamoPackages.dll"),
        Path.Combine(baseDir, "DynamoUnits.dll"),
        Path.Combine(baseDir, "GeometryColor.dll"),
        Path.Combine(baseDir, "GeometryColor.dll"),
        Path.Combine(baseDir, "GraphLayout.dll"),

        Path.Combine(baseDir, "Analysis.dll"),
        Path.Combine(baseDir, "DynamoConversions.dll"),
        Path.Combine(baseDir, "DynamoManipulation.dll"),
        //Path.Combine(baseDir, "Microsoft.Office.Interop.Excel.dll"),

        };
       
        public string UserDataRootFolder => "";
        public string CommonDataRootFolder => "";
    }
}
