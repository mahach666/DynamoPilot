using System.Collections.Generic;
using System.Linq;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace ServerOrganisationUnit
{
    /// <summary>
    /// Узлы для загрузки организационных единиц.
    /// </summary>
    [NodeCategory("Pilot.Server.OrganisationUnit")]
    [NodeDescription("Получение орг. единиц через серверное API")]
    public static class Get
    {
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
            var converted = ids?.ToArray() ?? System.Array.Empty<int>();
            return converted.Length == 0 ? new List<DOrganisationUnit>() : srv.LoadOrganisationUnitsByIds(converted);
        }

        /// <summary>
        /// Загрузка оргединиц через админ-сессию (ServerAdminApi).
        /// </summary>
        [NodeName("LoadOrganisationUnitsAdmin")]
        [IsDesignScriptCompatible]
        public static IList<DOrganisationUnit> LoadOrganisationUnits(ServerAdminSession session)
        {
            var srv = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return srv.LoadOrganisationUnits();
        }

        /// <summary>
        /// Загрузка оргединиц по id через админ-сессию (ServerAdminApi).
        /// </summary>
        [NodeName("LoadOrganisationUnitsByIdsAdmin")]
        [IsDesignScriptCompatible]
        public static IList<DOrganisationUnit> LoadOrganisationUnitsByIds(ServerAdminSession session, IList<int> ids)
        {
            var srv = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            var converted = ids?.ToArray() ?? System.Array.Empty<int>();
            if (converted.Length == 0)
                return new List<DOrganisationUnit>();

            var all = srv.LoadOrganisationUnits() ?? new List<DOrganisationUnit>();
            var set = new HashSet<int>(converted);
            return all.Where(p => set.Contains(p.Id)).ToList();
        }
    }
}

