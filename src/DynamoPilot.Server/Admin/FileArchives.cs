using System;
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
    /// Управление файловыми архивами.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.FileArchives")]
    [NodeDescription("Добавление/удаление/состояние файловых архивов")]
    public static class FileArchives
    {
        [NodeName("AddFileArchive")]
        [IsDesignScriptCompatible]
        public static Guid AddFileArchive(ServerSession session, string database, string faName, FileArchiveRecord faRecord)
        {
            return SessionGuard.EnsureAdmin(session).AddFileArchiveToDatabase2(database, faName, faRecord);
        }

        [NodeName("DeleteFileArchive")]
        [IsDesignScriptCompatible]
        public static bool DeleteFileArchive(ServerSession session, string database, Guid faId)
        {
            return SessionGuard.EnsureAdmin(session).DeleteFileArchiveFromDatabase(database, faId);
        }

        [NodeName("CanDeleteFileArchive")]
        [IsDesignScriptCompatible]
        public static bool CanDeleteFileArchive(ServerSession session, string database, Guid faId)
        {
            return SessionGuard.EnsureAdmin(session).CanDeleteFileArchiveFromDatabase(database, faId);
        }

        [NodeName("RenameFileArchive")]
        [IsDesignScriptCompatible]
        public static void RenameFileArchive(ServerSession session, string databaseName, Guid faId, string newName)
        {
            SessionGuard.EnsureAdmin(session).RenameFileArchive(databaseName, faId, newName);
        }

        [NodeName("SetArchiveWritable")]
        [IsDesignScriptCompatible]
        public static void SetArchiveWritable(ServerSession session, string databaseName, Guid selectedId)
        {
            SessionGuard.EnsureAdmin(session).SetFileArchiveAsWritable(databaseName, selectedId);
        }

        [NodeName("FileArchiveCapacity")]
        [IsDesignScriptCompatible]
        public static IList<KeyValuePair<string, long>> FileArchiveCapacity(ServerSession session, string database)
        {
            var dict = SessionGuard.EnsureAdmin(session).FileArchiveCapacity(database);
            var list = new List<KeyValuePair<string, long>>();
            foreach (var kv in dict)
            {
                list.Add(new KeyValuePair<string, long>(kv.Key.ToString(), kv.Value));
            }
            return list;
        }

        [NodeName("GetFileArchivesInfo")]
        [IsDesignScriptCompatible]
        public static IEnumerable<DFileArchiveRecordData> GetFileArchivesInfo(ServerSession session, string databaseName)
        {
            return SessionGuard.EnsureAdmin(session).GetFileArchivesInfo(databaseName);
        }

        [NodeName("GetFileArchivesInfoFullPath")]
        [IsDesignScriptCompatible]
        public static IEnumerable<DFileArchiveRecordData> GetFileArchivesInfoFullPath(ServerSession session, string databaseName, string databaseFullPath)
        {
            return SessionGuard.EnsureAdmin(session).GetFileArchivesInfo(databaseName, databaseFullPath);
        }
    }
}

