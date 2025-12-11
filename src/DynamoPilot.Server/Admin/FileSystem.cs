using System.Collections.Generic;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace ServerAdminFileSystem
{
    /// <summary>
    /// Управление файловыми папками через ServerAdminApi.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.FileSystem")]
    [NodeDescription("Работа с файловой системой серверных баз через ServerAdminApi")]
    public static class FileSystem
    {
        [NodeName("GetFileSystemNodes")]
        [IsDesignScriptCompatible]
        public static IEnumerable<FileSystemNode> GetFileSystemNodes(ServerAdminSession session, FileSystemNode parent, string fileExtensionFilter = null, bool showNetworkFolders = false)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.GetFileSystemNodes(parent, fileExtensionFilter, showNetworkFolders) ?? new List<FileSystemNode>();
        }

        [NodeName("RenameFolder")]
        [IsDesignScriptCompatible]
        public static void RenameFolder(ServerAdminSession session, string oldPath, string newPath)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.RenameFolder(oldPath, newPath);
        }

        [NodeName("DeleteFolder")]
        [IsDesignScriptCompatible]
        public static void DeleteFolder(ServerAdminSession session, string path)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.DeleteFolder(path);
        }

        [NodeName("CreateFolder")]
        [IsDesignScriptCompatible]
        public static void CreateFolder(ServerAdminSession session, string path)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.CreateFolder(path);
        }

        [NodeName("GetFreeSpace")]
        [IsDesignScriptCompatible]
        public static long GetFreeSpace(ServerAdminSession session, string path)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.GetFreeSpace(path);
        }

        [NodeName("GetParentFolder")]
        [IsDesignScriptCompatible]
        public static string GetParentFolder(ServerAdminSession session, string filePath)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.GetParentFolder(filePath);
        }
    }
}

