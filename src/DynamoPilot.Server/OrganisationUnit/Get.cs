using System.Collections.Generic;
using System.Linq;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace SOrganisationUnit
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

        /// <summary>
        /// Загрузка орг. единиц с учетом версии изменений.
        /// </summary>
        [NodeName("LoadOrganisationUnitsSince")]
        [IsDesignScriptCompatible]
        public static IList<DOrganisationUnit> LoadOrganisationUnits(ServerSession session, long lastKnownChange)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            return srv.LoadOrganisationUnits(lastKnownChange);
        }

        [NodeName("LoadOrganisationUnitsByIds")]
        [IsDesignScriptCompatible]
        public static IList<DOrganisationUnit> LoadOrganisationUnitsByIds(ServerSession session, IList<int> ids)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            var converted = ids?.ToArray() ?? System.Array.Empty<int>();
            return converted.Length == 0 ? new List<DOrganisationUnit>() : srv.LoadOrganisationUnitsByIds(converted);
        }

    }
}

