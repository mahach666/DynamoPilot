using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServerData
{
    /// <summary>
    /// Узлы для работы с объектами и метаданными через серверное API.
    /// </summary>
    [NodeCategory("Pilot.Server.Data")]
    [NodeDescription("Получение объектов и метаданных через серверное API Pilot")]
    public static class ServerData
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

        [NodeName("GetObjects")]
        [IsDesignScriptCompatible]
        public static IList<DObject> GetObjects(ServerSession session, IList<string> ids)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            var guidIds = SessionGuard.ParseGuids(ids ?? Array.Empty<string>());
            return guidIds.Length == 0
                ? new List<DObject>()
                : srv.GetObjects(guidIds);
        }

        [NodeName("GetChangesets")]
        [IsDesignScriptCompatible]
        public static IList<DChangeset> GetChangesets(ServerSession session, long first, long last)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            return srv.GetChangesets(first, last);
        }

        [NodeName("LoadPeople")]
        [IsDesignScriptCompatible]
        public static IList<DPerson> LoadPeople(ServerSession session)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            return srv.LoadPeople();
        }

        [NodeName("LoadPeopleByIds")]
        [IsDesignScriptCompatible]
        public static IList<DPerson> LoadPeopleByIds(ServerSession session, IList<int> ids)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            var converted = ids?.ToArray() ?? Array.Empty<int>();
            return converted.Length == 0 ? new List<DPerson>() : srv.LoadPeopleByIds(converted);
        }

        [NodeName("LoadOrganisationUnits")]
        [IsDesignScriptCompatible]
        public static IList<DOrganisationUnit> LoadOrganisationUnits(ServerSession session)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            return srv.LoadOrganisationUnits();
        }

        [NodeName("LoadOrganisationUnitsByIds")]
        [IsDesignScriptCompatible]
        public static IList<DOrganisationUnit> LoadOrganisationUnitsByIds(ServerSession session, IList<int> ids)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            var converted = ids?.ToArray() ?? Array.Empty<int>();
            return converted.Length == 0 ? new List<DOrganisationUnit>() : srv.LoadOrganisationUnitsByIds(converted);
        }

        [NodeName("GetDatabaseInfo")]
        [IsDesignScriptCompatible]
        public static DDatabaseInfo GetDatabase(ServerSession session, string databaseName)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            return srv.GetDatabase(databaseName);
        }

        [NodeName("GetPersonalSettings")]
        [IsDesignScriptCompatible]
        public static DSettings GetPersonalSettings(ServerSession session)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            return srv.GetPersonalSettings();
        }

        [NodeName("GetCommonSettings")]
        [IsDesignScriptCompatible]
        public static DSettings GetCommonSettings(ServerSession session)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            return srv.GetCommonSettings();
        }

        [NodeName("ChangeSettings")]
        [IsDesignScriptCompatible]
        public static void ChangeSettings(ServerSession session, DSettingsChange change)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            srv.ChangeSettings(change);
        }

        [NodeName("ApplyChanges")]
        [IsDesignScriptCompatible]
        public static DChangeset ApplyChanges(ServerSession session, DChangesetData changes)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            return srv.Change(changes);
        }

        [NodeName("UpdatePerson")]
        [IsDesignScriptCompatible]
        public static void UpdatePerson(ServerSession session, DPersonUpdateInfo updateInfo)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            srv.UpdatePerson(updateInfo);
        }

        [NodeName("UpdateOrganisationUnit")]
        [IsDesignScriptCompatible]
        public static void UpdateOrganisationUnit(ServerSession session, DOrganisationUnitUpdateInfo updateInfo)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            srv.UpdateOrganisationUnit(updateInfo);
        }

        [NodeName("GetHistoryItems")]
        [IsDesignScriptCompatible]
        public static IList<DHistoryItem> GetHistoryItems(ServerSession session, IList<string> ids)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            var guidIds = SessionGuard.ParseGuids(ids ?? Array.Empty<string>());
            return guidIds.Length == 0
                ? new List<DHistoryItem>()
                : srv.GetHistoryItems(guidIds).ToList();
        }

        [NodeName("AddSearch")]
        [IsDesignScriptCompatible]
        public static void AddSearch(ServerSession session, DSearchDefinition searchDefinition)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            srv.AddSearch(searchDefinition);
        }

        [NodeName("RemoveSearch")]
        [IsDesignScriptCompatible]
        public static void RemoveSearch(ServerSession session, string definitionId)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            if (Guid.TryParse(definitionId, out var id))
                srv.RemoveSearch(id);
        }
    }
}

