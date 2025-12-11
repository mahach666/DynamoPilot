using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServerAdmin.FileArchive
{
    /// <summary>
    /// Чтение информации о файловых архивах.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.FileArchive")]
    [NodeDescription("Чтение состояния и информации архивов через ServerAdminApi")]
    public static class Get
    {
        [NodeName("FileArchiveCapacity")]
        [IsDesignScriptCompatible]
        public static IDictionary<Guid, long> FileArchiveCapacity(ServerAdminSession session, string database)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.FileArchiveCapacity(database) ?? new Dictionary<Guid, long>();
        }

        [NodeName("GetFileArchivesInfo")]
        [IsDesignScriptCompatible]
        public static IList<DFileArchiveRecordData> GetFileArchivesInfo(ServerAdminSession session, string databaseName)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.GetFileArchivesInfo(databaseName)?.ToList() ?? new List<DFileArchiveRecordData>();
        }

        [NodeName("GetFileArchivesInfoByPath")]
        [IsDesignScriptCompatible]
        public static IList<DFileArchiveRecordData> GetFileArchivesInfo(ServerAdminSession session, string databaseName, string databaseFullPath)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.GetFileArchivesInfo(databaseName, databaseFullPath)?.ToList() ?? new List<DFileArchiveRecordData>();
        }

        [NodeName("GetFileArchiveCheckState")]
        [IsDesignScriptCompatible]
        public static DFileArchiveCheckState GetFileArchiveCheckState(ServerAdminSession session, string databaseName)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.GetFileArchiveCheckState(databaseName);
        }

        [NodeName("GetFileArchiveCheckResult")]
        [IsDesignScriptCompatible]
        public static byte[] GetFileArchiveCheckResult(ServerAdminSession session, string databaseName, DateTime checkTimestamp)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.GetFileArchiveCheckResult(databaseName, checkTimestamp) ?? Array.Empty<byte>();
        }

        [NodeName("GetFileMigrationCheckState")]
        [IsDesignScriptCompatible]
        public static DFileArchiveCheckState GetFileMigrationCheckState(ServerAdminSession session, string databaseName)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.GetFileMigrationCheckState(databaseName);
        }

        [NodeName("GetFileArchiveMigrationResult")]
        [IsDesignScriptCompatible]
        public static byte[] GetFileArchiveMigrationResult(ServerAdminSession session, string databaseName, DateTime checkTimestamp)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.GetFileArchiveMigrationResult(databaseName, checkTimestamp) ?? Array.Empty<byte>();
        }
    }

    /// <summary>
    /// Изменение архивов, проверок, миграций.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.FileArchive")]
    [NodeDescription("Изменение архивов, проверок и миграций через ServerAdminApi")]
    public static class Edit
    {
        [NodeName("AddFileArchiveToDatabase")]
        [IsDesignScriptCompatible]
        public static Guid AddFileArchiveToDatabase(ServerAdminSession session, string database, string faName, string faFolder)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.AddFileArchiveToDatabase(database, faName, faFolder);
        }

        [NodeName("DeleteFileArchiveFromDatabase")]
        [IsDesignScriptCompatible]
        public static bool DeleteFileArchiveFromDatabase(ServerAdminSession session, string database, Guid faId)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.DeleteFileArchiveFromDatabase(database, faId);
        }

        [NodeName("CanDeleteFileArchiveFromDatabase")]
        [IsDesignScriptCompatible]
        public static bool CanDeleteFileArchiveFromDatabase(ServerAdminSession session, string database, Guid faId)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.CanDeleteFileArchiveFromDatabase(database, faId);
        }

        [NodeName("RenameFileArchive")]
        [IsDesignScriptCompatible]
        public static void RenameFileArchive(ServerAdminSession session, string databaseName, Guid faId, string newName)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.RenameFileArchive(databaseName, faId, newName);
        }

        [NodeName("SetFileArchiveAsWritable")]
        [IsDesignScriptCompatible]
        public static void SetFileArchiveAsWritable(ServerAdminSession session, string databaseName, Guid selectedId)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.SetFileArchiveAsWritable(databaseName, selectedId);
        }

        [NodeName("StartFileArchiveCheck")]
        [IsDesignScriptCompatible]
        public static void StartFileArchiveCheck(ServerAdminSession session, string databaseName, bool validateChecksum, bool validateUnlinkedFiles = false)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.StartFileArchiveCheck(databaseName, validateChecksum, validateUnlinkedFiles);
        }

        [NodeName("StopFileArchiveCheck")]
        [IsDesignScriptCompatible]
        public static void StopFileArchiveCheck(ServerAdminSession session, string databaseName)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.StopFileArchiveCheck(databaseName);
        }

        [NodeName("StartFileMigrationCheck")]
        [IsDesignScriptCompatible]
        public static void StartFileMigrationCheck(ServerAdminSession session, string databaseName, Guid faFrom, DateTime from, DateTime to, bool all, bool actual, string extMask)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.StartFileMigrationCheck(databaseName, faFrom, from, to, all, actual, extMask);
        }

        [NodeName("StartFileMigrationCheckWithParent")]
        [IsDesignScriptCompatible]
        public static void StartFileMigrationCheck(ServerAdminSession session, string databaseName, Guid faFrom, DateTime from, DateTime to, bool all, bool actual, string extMask, Guid parentObjectId)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.StartFileMigrationCheck(databaseName, faFrom, from, to, all, actual, extMask, parentObjectId);
        }

        [NodeName("StopFileMigrationCheck")]
        [IsDesignScriptCompatible]
        public static void StopFileMigrationCheck(ServerAdminSession session, string databaseName)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.StopFileMigrationCheck(databaseName);
        }

        [NodeName("StartFileArchiveMigration")]
        [IsDesignScriptCompatible]
        public static void StartFileArchiveMigration(ServerAdminSession session, string databaseName, Guid faFrom, Guid faTo, DateTime from, DateTime to, bool all, bool actual, string extMask)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.StartFileArchiveMigration(databaseName, faFrom, faTo, from, to, all, actual, extMask);
        }

        [NodeName("StartFileArchiveMigrationWithParent")]
        [IsDesignScriptCompatible]
        public static void StartFileArchiveMigration(ServerAdminSession session, string databaseName, Guid faFrom, Guid faTo, DateTime from, DateTime to, bool all, bool actual, string extMask, Guid parentObjectId)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.StartFileArchiveMigration(databaseName, faFrom, faTo, from, to, all, actual, extMask, parentObjectId);
        }

        [NodeName("StopFileArchiveMigration")]
        [IsDesignScriptCompatible]
        public static void StopFileArchiveMigration(ServerAdminSession session, string databaseName)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.StopFileArchiveMigration(databaseName);
        }

        [NodeName("StartFileArchiveCleanup")]
        [IsDesignScriptCompatible]
        public static void StartFileArchiveCleanup(ServerAdminSession session, string databaseName, string targetFolder)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.StartFileArchiveCleanup(databaseName, targetFolder);
        }

        [NodeName("StopFileArchiveCleanup")]
        [IsDesignScriptCompatible]
        public static void StopFileArchiveCleanup(ServerAdminSession session, string databaseName)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.StopFileArchiveCleanup(databaseName);
        }

        [NodeName("CleanOperation")]
        [IsDesignScriptCompatible]
        public static void CleanOperation(ServerAdminSession session, string databaseName)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.CleanOperation(databaseName);
        }
    }
}

