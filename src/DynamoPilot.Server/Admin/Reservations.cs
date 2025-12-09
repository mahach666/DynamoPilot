using System;
using System.Collections.Generic;
using Ascon.Pilot.DataClasses;
using Ascon.Pilot.Server.Api.Contracts;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace ServerAdmin
{
    /// <summary>
    /// Резервации лицензий/продуктов.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.Reservations")]
    [NodeDescription("Чтение и управление резервациями")]
    public static class Reservations
    {
        [NodeName("GetReservations")]
        [IsDesignScriptCompatible]
        public static IEnumerable<DReservation> GetReservations(ServerSession session)
        {
            return SessionGuard.EnsureAdmin(session).GetReservations();
        }

        [NodeName("UpdateReservations")]
        [IsDesignScriptCompatible]
        public static void UpdateReservations(ServerSession session, DReservation value)
        {
            SessionGuard.EnsureAdmin(session).UpdateReservations(value);
        }

        [NodeName("DeleteReservationByDatabaseId")]
        [IsDesignScriptCompatible]
        public static void DeleteReservationByDatabaseId(ServerSession session, Guid databaseId)
        {
            SessionGuard.EnsureAdmin(session).DeleteReservationByDataBaseId(databaseId);
        }

        [NodeName("DeleteReservationById")]
        [IsDesignScriptCompatible]
        public static void DeleteReservationById(ServerSession session, Guid id)
        {
            SessionGuard.EnsureAdmin(session).DeleteReservationById(id);
        }

        [NodeName("DeleteReservationByOrgUnit")]
        [IsDesignScriptCompatible]
        public static void DeleteReservationByOrgUnit(ServerSession session, Guid databaseId, int orgUnitId)
        {
            SessionGuard.EnsureAdmin(session).DeleteReservationByOrUnitId(databaseId, orgUnitId);
        }

        [NodeName("GetReservationsCountByProducts")]
        [IsDesignScriptCompatible]
        public static Dictionary<int, int> GetReservationsCountByProducts(ServerSession session, IEnumerable<int> products, Guid? licenseId = null)
        {
            var list = products as int[] ?? (products != null ? new List<int>(products).ToArray() : Array.Empty<int>());
            return licenseId.HasValue
                ? SessionGuard.EnsureAdmin(session).GetReservationsCountByProducts(list, licenseId.Value)
                : SessionGuard.EnsureAdmin(session).GetReservationsCountByProducts(list);
        }
    }
}

