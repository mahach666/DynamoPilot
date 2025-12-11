using System;
using System.Collections.Generic;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;
using System.Linq;

namespace SObjectAccess
{
    /// <summary>
    /// Узлы для работы с правами доступа объектов.
    /// </summary>
    [NodeCategory("Pilot.Server.Object.Access")]
    [NodeDescription("Загрузка прав доступа и расчет AccessLevel через ServerApi")]
    public static class Access
    {
        [NodeName("LoadAccessRecords")]
        [IsDesignScriptCompatible]
        public static IList<AccessRecord> LoadAccessRecords(ServerSession session, string objectId)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            var guid = Guid.Parse(objectId);
            return srv.LoadAccessRecords(guid)?.ToList() ?? new List<AccessRecord>();
        }

        [NodeName("LoadAccessRecordsBatch")]
        [IsDesignScriptCompatible]
        public static IList<IList<AccessRecord>> LoadAccessRecordsBatch(ServerSession session, IList<string> objectIds)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            var guids = SessionGuard.ParseGuids(objectIds ?? Enumerable.Empty<string>());
            if (guids.Length == 0)
                return new List<IList<AccessRecord>>();

            var result = srv.LoadAccessRecordsBatch(guids);
            if (result == null)
                return new List<IList<AccessRecord>>();

            return result
                .Select(r => (IList<AccessRecord>)(r?.ToList() ?? new List<AccessRecord>()))
                .ToList();
        }

        [NodeName("CalcAccessByPerson")]
        [IsDesignScriptCompatible]
        public static AccessLevel CalcAccessByPerson(ServerSession session, string objectId, int personId)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            var guid = Guid.Parse(objectId);
            return srv.CalcAccessByPerson(guid, personId);
        }

        [NodeName("CalcAccessByUnit")]
        [IsDesignScriptCompatible]
        public static AccessLevel CalcAccessByUnit(ServerSession session, string objectId, int unitId)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            var guid = Guid.Parse(objectId);
            return srv.CalcAccessByUnit(guid, unitId);
        }

        [NodeName("GetSubscribers")]
        [IsDesignScriptCompatible]
        public static IList<int> GetSubscribers(ServerSession session, string objectId)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            var guid = Guid.Parse(objectId);
            return srv.GetSubscribers(guid) ?? new List<int>();
        }
    }
}

