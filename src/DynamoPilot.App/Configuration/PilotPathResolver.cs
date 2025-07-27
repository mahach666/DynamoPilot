using Dynamo.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DynamoPilot.App.Configuration
{
    class PilotPathResolver : IPathResolver
    {
        private readonly string pkgDir;
        public PilotPathResolver(string dir) => pkgDir = dir;

        //public IEnumerable<string> PackageDirectories => new[] { pkgDir };
        public IEnumerable<string> AdditionalNodeDirectories => new string[0];
        public IEnumerable<string> AdditionalResolutionPaths => new[] { Path.Combine(pkgDir) };
        public IEnumerable<string> PreloadedLibraryPaths => Enumerable.Empty<string>();

        public string UserDataRootFolder => "";
        public string CommonDataRootFolder => "";
    }
}
