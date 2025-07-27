using Dynamo.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DynamoPilot.App.Configuration
{
    class PilotPathResolver : IPathResolver
    {
        private readonly string customDir;   // сюда передаём nodesDir

        public PilotPathResolver(string dir) => customDir = dir;

        // Папка с .dyf и zero‑touch dll
        public IEnumerable<string> AdditionalNodeDirectories => new[] { customDir };

        // Путь, в котором может понадобиться найти зависимости dll
        public IEnumerable<string> AdditionalResolutionPaths => new[] { customDir };

        // Если в вашей версии IPathResolver есть это свойство – добавьте и его
        public IEnumerable<string> PackageDirectories => new[] { customDir };

        public IEnumerable<string> PreloadedLibraryPaths => Enumerable.Empty<string>();

        public string UserDataRootFolder => "";
        public string CommonDataRootFolder => "";
    }
}
