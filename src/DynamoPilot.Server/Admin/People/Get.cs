using System.Collections.Generic;
using System.Linq;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace Admin.People
{
    /// <summary>
    /// Загрузка пользователей через ServerAdminApi.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.People")]
    [NodeDescription("Загрузка пользователей через ServerAdminApi")]
    public static class Get
    {
        [NodeName("LoadPeopleAdmin")]
        [IsDesignScriptCompatible]
        public static IList<DPerson> LoadPeople(ServerAdminSession session)
        {
            var srv = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return srv.LoadPeople();
        }

        [NodeName("LoadPeopleByIdsAdmin")]
        [IsDesignScriptCompatible]
        public static IList<DPerson> LoadPeopleByIds(ServerAdminSession session, IList<int> ids)
        {
            var srv = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            var converted = ids?.ToArray() ?? System.Array.Empty<int>();
            if (converted.Length == 0)
                return new List<DPerson>();

            var all = srv.LoadPeople() ?? new List<DPerson>();
            var set = new HashSet<int>(converted);
            return all.Where(p => set.Contains(p.Id)).ToList();
        }
    }
}

