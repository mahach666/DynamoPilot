using System.Collections.Generic;
using Ascon.Pilot.DataClasses;
using Ascon.Pilot.Server.Api.Contracts;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace ServerAdmin
{
    /// <summary>
    /// Администрирование баз данных.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.Database")]
    [NodeDescription("Операции с базами данных")]
    public static class Database
    {
        [NodeName("GetDatabaseInfoList")]
        [IsDesignScriptCompatible]
        public static IList<AdminDatabaseInfo> GetDatabaseInfoList(ServerSession session)
        {
            return SessionGuard.EnsureAdmin(session).GetDatabaseInfoList();
        }

        [NodeName("CreateDatabase")]
        [IsDesignScriptCompatible]
        public static void CreateDatabase(ServerSession session, string databaseName, string databaseDirectory, FileArchiveRecord fileArchiveRecord)
        {
            SessionGuard.EnsureAdmin(session).CreateDatabase2(databaseName, databaseDirectory, fileArchiveRecord);
        }

        [NodeName("AddDatabase")]
        [IsDesignScriptCompatible]
        public static void AddDatabase(ServerSession session, string databaseName, string databaseFilename, IList<FileArchiveRecord> faRecords)
        {
            SessionGuard.EnsureAdmin(session).AddDatabase2(databaseName, databaseFilename, faRecords as List<FileArchiveRecord> ?? new List<FileArchiveRecord>(faRecords));
        }

        [NodeName("DetachDatabase")]
        [IsDesignScriptCompatible]
        public static void DetachDatabase(ServerSession session, string databaseName)
        {
            SessionGuard.EnsureAdmin(session).DetachDatabase(databaseName);
        }

        [NodeName("DetachAsNewDatabase")]
        [IsDesignScriptCompatible]
        public static void DetachAsNewDatabase(ServerSession session, string databaseName)
        {
            SessionGuard.EnsureAdmin(session).DetachAsNewDatabase(databaseName);
        }

        [NodeName("RenameDatabase")]
        [IsDesignScriptCompatible]
        public static void RenameDatabase(ServerSession session, string oldName, string newName)
        {
            SessionGuard.EnsureAdmin(session).RenameDatabase(oldName, newName);
        }

        [NodeName("SetDatabaseState")]
        [IsDesignScriptCompatible]
        public static void SetDatabaseState(ServerSession session, string databaseName, int state)
        {
            SessionGuard.EnsureAdmin(session).SetDatabaseState(databaseName, state);
        }

        [NodeName("OpenDatabase")]
        [IsDesignScriptCompatible]
        public static void OpenDatabase(ServerSession session, string databaseName)
        {
            SessionGuard.EnsureAdmin(session).OpenDatabase(databaseName);
        }
    }
}

