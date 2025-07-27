using Dynamo.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;

namespace DynamoPilot.App.Configuration
{
    [Export(typeof(IPathResolver))]
    class PilotPathResolver : IPathResolver
    {
        private readonly string pkgs;
        public PilotPathResolver(string pkgsDir) => pkgs = pkgsDir;

        // сканировать packages\**  (пакетная структура)
        public IEnumerable<string> PackageDirectories => new[] { pkgs };

        // если DLL имеет сторонние зависимости – где их искать
        public IEnumerable<string> AdditionalResolutionPaths => new[] { Path.Combine(pkgs, "DynamoPilot", "bin") };

        // остальные можно оставить пустыми
        public IEnumerable<string> AdditionalNodeDirectories => Enumerable.Empty<string>();
        public IEnumerable<string> PreloadedLibraryPaths => Enumerable.Empty<string>();
        public string UserDataRootFolder => ""; public string CommonDataRootFolder => "";
    }
}
