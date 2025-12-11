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

    }
}

