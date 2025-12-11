using System.Collections.Generic;
using System.Linq;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace SPeople
{
    /// <summary>
    /// Узлы для загрузки пользователей.
    /// </summary>
    [NodeCategory("Pilot.Server.People")]
    [NodeDescription("Получение пользователей через серверное API")]
    public static class Get
    {
        [NodeName("LoadPeople")]
        [IsDesignScriptCompatible]
        public static IList<DPerson> LoadPeople(ServerSession session)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            return srv.LoadPeople();
        }

        /// <summary>
        /// Загружает пользователей, измененных после указанной версии.
        /// </summary>
        [NodeName("LoadPeopleSince")]
        [IsDesignScriptCompatible]
        public static IList<DPerson> LoadPeople(ServerSession session, long lastKnownChange)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            return srv.LoadPeople(lastKnownChange);
        }

        [NodeName("LoadPeopleByIds")]
        [IsDesignScriptCompatible]
        public static IList<DPerson> LoadPeopleByIds(ServerSession session, IList<int> ids)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            var converted = ids?.ToArray() ?? System.Array.Empty<int>();
            return converted.Length == 0 ? new List<DPerson>() : srv.LoadPeopleByIds(converted);
        }

        /// <summary>
        /// Загрузка пользователей через админ-сессию (ServerAdminApi).
        /// </summary>
        [NodeName("LoadPeopleAdmin")]
        [IsDesignScriptCompatible]
        public static IList<DPerson> LoadPeople(ServerAdminSession session)
        {
            var srv = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return srv.LoadPeople();
        }

        /// <summary>
        /// Загрузка пользователей по id через админ-сессию (ServerAdminApi).
        /// </summary>
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

