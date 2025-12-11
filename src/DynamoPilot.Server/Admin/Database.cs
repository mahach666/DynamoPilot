using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;
using System.Collections.Generic;

namespace Admin.Database
{
    /// <summary>
    /// Получение информации о базах данных (IServerAdminApi).
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.Database")]
    [NodeDescription("Получение информации о базах данных через ServerAdminApi")]
    public static class Get
    {
        [NodeName("GetDatabaseInfoList")]
        [IsDesignScriptCompatible]
        public static IList<AdminDatabaseInfo> GetDatabaseInfoList(ServerAdminSession session)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.GetDatabaseInfoList() ?? new List<AdminDatabaseInfo>();
        }

        [NodeName("OpenDatabaseAdmin")]
        [IsDesignScriptCompatible]
        public static void OpenDatabase(ServerAdminSession session, string databaseName)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.OpenDatabase(databaseName);
        }
    }

    /// <summary>
    /// Изменение/создание баз данных (IServerAdminApi).
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.Database")]
    [NodeDescription("Создание, добавление, отсоединение и переименование баз через ServerAdminApi")]
    public static class Edit
    {
        [NodeName("CreateDatabase")]
        [IsDesignScriptCompatible]
        public static void CreateDatabase(ServerAdminSession session, string databaseName, string databaseDirectory, string fileArchiveFoldersList)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.CreateDatabase(databaseName, databaseDirectory, fileArchiveFoldersList);
        }

        [NodeName("AddDatabase")]
        [IsDesignScriptCompatible]
        public static void AddDatabase(ServerAdminSession session, string databaseName, string databaseFilename, IList<string> faFolders)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.AddDatabase(databaseName, databaseFilename, faFolders == null ? new List<string>() : new List<string>(faFolders));
        }

        [NodeName("DetachDatabase")]
        [IsDesignScriptCompatible]
        public static void DetachDatabase(ServerAdminSession session, string databaseName)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.DetachDatabase(databaseName);
        }

        [NodeName("DetachAsNewDatabase")]
        [IsDesignScriptCompatible]
        public static void DetachAsNewDatabase(ServerAdminSession session, string databaseName)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.DetachAsNewDatabase(databaseName);
        }

        [NodeName("RenameDatabase")]
        [IsDesignScriptCompatible]
        public static void RenameDatabase(ServerAdminSession session, string oldName, string newName)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.RenameDatabase(oldName, newName);
        }

        [NodeName("SetDatabaseState")]
        [IsDesignScriptCompatible]
        public static void SetDatabaseState(ServerAdminSession session, string databaseName, int state)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.SetDatabaseState(databaseName, state);
        }
    }
}

