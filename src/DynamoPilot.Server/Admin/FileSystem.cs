using System.Collections.Generic;
using System.Linq;
using Ascon.Pilot.DataClasses;
using Ascon.Pilot.Server.Api.Contracts;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace ServerAdmin
{
    /// <summary>
    /// Файловые операции на сервере.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.FileSystem")]
    [NodeDescription("Получение и управление файловой системой серверных архивов")]
    public static class FileSystem
    {
        [NodeName("GetFileSystemNodes")]
        [IsDesignScriptCompatible]
        public static List<FileSystemNode> GetFileSystemNodes(ServerSession session, FileSystemNode parent, string fileExtensionFilter, bool showNetworkFolders)
        {
            return SessionGuard.EnsureAdmin(session).GetFileSystemNodes(parent, fileExtensionFilter, showNetworkFolders).ToList();
        }

        [NodeName("RenameFolder")]
        [IsDesignScriptCompatible]
        public static void RenameFolder(ServerSession session, string oldPath, string newPath)
        {
            SessionGuard.EnsureAdmin(session).RenameFolder(oldPath, newPath);
        }

        [NodeName("DeleteFolder")]
        [IsDesignScriptCompatible]
        public static void DeleteFolder(ServerSession session, string path)
        {
            SessionGuard.EnsureAdmin(session).DeleteFolder(path);
        }

        [NodeName("CreateFolder")]
        [IsDesignScriptCompatible]
        public static void CreateFolder(ServerSession session, string path)
        {
            SessionGuard.EnsureAdmin(session).CreateFolder(path);
        }

        [NodeName("GetFreeSpace")]
        [IsDesignScriptCompatible]
        public static long GetFreeSpace(ServerSession session, string path)
        {
            return SessionGuard.EnsureAdmin(session).GetFreeSpace(path);
        }

        [NodeName("GetParentFolder")]
        [IsDesignScriptCompatible]
        public static string GetParentFolder(ServerSession session, string filePath)
        {
            return SessionGuard.EnsureAdmin(session).GetParentFolder(filePath);
        }
    }
}

