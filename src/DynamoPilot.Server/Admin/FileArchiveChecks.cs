using System;
using Ascon.Pilot.DataClasses;
using Ascon.Pilot.Server.Api.Contracts;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace ServerAdmin
{
    /// <summary>
    /// Проверки и миграции файловых архивов.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.FileArchiveChecks")]
    [NodeDescription("Проверки, миграции и очистка архивов")]
    public static class FileArchiveChecks
    {
        [NodeName("StartFileArchiveCheck")]
        [IsDesignScriptCompatible]
        public static void StartFileArchiveCheck(ServerSession session, string databaseName, bool validateChecksum, bool validateUnlinkedFiles = false)
        {
            SessionGuard.EnsureAdmin(session).StartFileArchiveCheck(databaseName, validateChecksum, validateUnlinkedFiles);
        }

        [NodeName("StopFileArchiveCheck")]
        [IsDesignScriptCompatible]
        public static void StopFileArchiveCheck(ServerSession session, string databaseName)
        {
            SessionGuard.EnsureAdmin(session).StopFileArchiveCheck(databaseName);
        }

        [NodeName("GetFileArchiveCheckState")]
        [IsDesignScriptCompatible]
        public static DFileArchiveCheckState GetFileArchiveCheckState(ServerSession session, string databaseName)
        {
            return SessionGuard.EnsureAdmin(session).GetFileArchiveCheckState(databaseName);
        }

        [NodeName("GetFileArchiveCheckResult")]
        [IsDesignScriptCompatible]
        public static string GetFileArchiveCheckResult(ServerSession session, string databaseName, DateTime checkTimestamp)
        {
            var data = SessionGuard.EnsureAdmin(session).GetFileArchiveCheckResult(databaseName, checkTimestamp);
            return data == null ? string.Empty : Convert.ToBase64String(data);
        }

        [NodeName("StartFileMigrationCheck")]
        [IsDesignScriptCompatible]
        public static void StartFileMigrationCheck(ServerSession session, string databaseName, Guid faFrom, DateTime from, DateTime to, bool all, bool actual, string extMask, string parentObjectId = null)
        {
            var admin = SessionGuard.EnsureAdmin(session);
            if (Guid.TryParse(parentObjectId, out var parsed))
                admin.StartFileMigrationCheck(databaseName, faFrom, from, to, all, actual, extMask, parsed);
            else
                admin.StartFileMigrationCheck(databaseName, faFrom, from, to, all, actual, extMask);
        }

        [NodeName("StopFileMigrationCheck")]
        [IsDesignScriptCompatible]
        public static void StopFileMigrationCheck(ServerSession session, string databaseName)
        {
            SessionGuard.EnsureAdmin(session).StopFileMigrationCheck(databaseName);
        }

        [NodeName("GetFileMigrationCheckState")]
        [IsDesignScriptCompatible]
        public static DFileArchiveCheckState GetFileMigrationCheckState(ServerSession session, string databaseName)
        {
            return SessionGuard.EnsureAdmin(session).GetFileMigrationCheckState(databaseName);
        }

        [NodeName("StartFileArchiveMigration")]
        [IsDesignScriptCompatible]
        public static void StartFileArchiveMigration(ServerSession session, string databaseName, Guid faFrom, Guid faTo, DateTime from, DateTime to, bool all, bool actual, string extMask, string parentObjectId = null)
        {
            var admin = SessionGuard.EnsureAdmin(session);
            if (Guid.TryParse(parentObjectId, out var parsed))
                admin.StartFileArchiveMigration(databaseName, faFrom, faTo, from, to, all, actual, extMask, parsed);
            else
                admin.StartFileArchiveMigration(databaseName, faFrom, faTo, from, to, all, actual, extMask);
        }

        [NodeName("StopFileArchiveMigration")]
        [IsDesignScriptCompatible]
        public static void StopFileArchiveMigration(ServerSession session, string databaseName)
        {
            SessionGuard.EnsureAdmin(session).StopFileArchiveMigration(databaseName);
        }

        [NodeName("StartFileArchiveCleanup")]
        [IsDesignScriptCompatible]
        public static void StartFileArchiveCleanup(ServerSession session, string databaseName, string targetFolder)
        {
            SessionGuard.EnsureAdmin(session).StartFileArchiveCleanup(databaseName, targetFolder);
        }

        [NodeName("StopFileArchiveCleanup")]
        [IsDesignScriptCompatible]
        public static void StopFileArchiveCleanup(ServerSession session, string databaseName)
        {
            SessionGuard.EnsureAdmin(session).StopFileArchiveCleanup(databaseName);
        }

        [NodeName("GetFileArchiveMigrationResult")]
        [IsDesignScriptCompatible]
        public static string GetFileArchiveMigrationResult(ServerSession session, string databaseName, DateTime checkTimestamp)
        {
            var data = SessionGuard.EnsureAdmin(session).GetFileArchiveMigrationResult(databaseName, checkTimestamp);
            return data == null ? string.Empty : Convert.ToBase64String(data);
        }

        [NodeName("CleanOperation")]
        [IsDesignScriptCompatible]
        public static void CleanOperation(ServerSession session, string databaseName)
        {
            SessionGuard.EnsureAdmin(session).CleanOperation(databaseName);
        }
    }
}

