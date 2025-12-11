using System.Collections.Generic;
using System.Linq;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace Admin.OrganisationUnit
{
    /// <summary>
    /// Загрузка оргструктуры через ServerAdminApi.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.OrganisationUnit")]
    [NodeDescription("Загрузка орг. единиц через ServerAdminApi")]
    public static class Get
    {
        [NodeName("LoadOrganisationUnitsAdmin")]
        [IsDesignScriptCompatible]
        public static IList<DOrganisationUnit> LoadOrganisationUnits(ServerAdminSession session)
        {
            var srv = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return srv.LoadOrganisationUnits();
        }

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

