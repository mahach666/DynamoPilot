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

        // сканировать packages\**  (пакетная структура)
        public IEnumerable<string> PackageDirectories => new[] { Path.Combine(baseDir, "packages"),
            Path.Combine(baseDir, "packages\\DynamoPilot"),
            Path.Combine(baseDir, "packages\\DynamoPilot\\bin"),

        };

        // если DLL имеет сторонние зависимости – где их искать
        public IEnumerable<string> AdditionalResolutionPaths => new string[] { baseDir,
            Path.Combine(baseDir, "packages"),
            Path.Combine(baseDir, "packages\\DynamoPilot"),
            Path.Combine(baseDir, "packages\\DynamoPilot\\bin"),
            Path.Combine(baseDir, "DynamoFeatureFlags"),
            Path.Combine(baseDir, "extensions"),
            Path.Combine(baseDir, "nodes") };

        // остальные можно оставить пустыми
        public IEnumerable<string> AdditionalNodeDirectories => new string[] { baseDir,
            Path.Combine(baseDir, "packages"),
            Path.Combine(baseDir, "packages\\DynamoPilot"),
            Path.Combine(baseDir, "packages\\DynamoPilot\\bin"),
            Path.Combine(baseDir, "DynamoFeatureFlags"),
            Path.Combine(baseDir, "extensions"),
            Path.Combine(baseDir, "nodes") };
        public IEnumerable<string> PreloadedLibraryPaths => new string[] {};
        public string UserDataRootFolder => ""; public string CommonDataRootFolder => "";
    }
}
