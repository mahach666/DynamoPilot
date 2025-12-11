using System;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace ServerDatabase
{
    /// <summary>
    /// Узлы для открытия базы и получения метаданных через серверное API.
    /// </summary>
    [NodeCategory("Pilot.Server.Database")]
    [NodeDescription("Работа с базой данных и метаданными")]
    public static class Get
    {
        [NodeName("OpenDatabase")]
        [IsDesignScriptCompatible]
        public static DDatabaseInfo OpenDatabase(ServerSession session)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            var db = srv.OpenDatabase();
            session.DatabaseInfo = db;
            return db;
        }

        [NodeName("RefreshMetadata")]
        [IsDesignScriptCompatible]
        public static DMetadata RefreshMetadata(ServerSession session, long localVersion = 0)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            var metadata = srv.GetMetadata(localVersion);
            session.Metadata = metadata;
            return metadata;
        }

        [NodeName("GetDatabaseInfo")]
        [IsDesignScriptCompatible]
        public static DDatabaseInfo GetDatabase(ServerSession session, string databaseName)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            return srv.GetDatabase(databaseName);
        }

        /// <summary>
        /// Возвращает информацию о текущей базе из открытой сессии.
        /// </summary>
        [NodeName("GetCurrentDatabaseInfo")]
        [IsDesignScriptCompatible]
        public static DDatabaseInfo GetCurrentDatabaseInfo(ServerSession session)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            return srv.GetDatabaseInfo();
        }
    }
}

