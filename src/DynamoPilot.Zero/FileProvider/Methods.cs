using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System;
using System.IO;

namespace FileProvider
{
    public static class Methods
    {
        [IsDesignScriptCompatible]
        public static void DeleteLocalFile(PFileProvider pFileProvider, Guid fileId)
        {
            pFileProvider.DeleteLocalFile(fileId);
        }

        [IsDesignScriptCompatible]
        public static bool Exists(PFileProvider pFileProvider, Guid fileId)
        {
            return pFileProvider.Exists(fileId);
        }

        [IsDesignScriptCompatible]
        public static long GetFileSizeOnDisk(PFileProvider pFileProvider, Guid fileId)
        {
            return pFileProvider.GetFileSizeOnDisk(fileId);
        }

        [IsDesignScriptCompatible]
        public static bool IsFull(PFileProvider pFileProvider, Guid fileId)
        {
            return pFileProvider.IsFull(fileId);
        }

        [IsDesignScriptCompatible]
        public static Stream OpenRead(PFileProvider pFileProvider, PFile file)
        {
            return pFileProvider.OpenRead((IFile)file.Unwrap());
        }
    }
}
