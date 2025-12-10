using System;
using System.Collections.Generic;
using System.Linq;
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
        public static List<DReservation> GetReservations(ServerSession session)
        {
            return SessionGuard.EnsureAdmin(session).GetReservations().ToList();
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
        public static IList<ServerAdmin.Models.ReservationCountInfo> GetReservationsCountByProducts(ServerSession session, IList<int> products, string licenseId = null)
        {
            var list = products?.ToArray() ?? Array.Empty<int>();
            Dictionary<int, int> dict;
            if (Guid.TryParse(licenseId, out var licId))
                dict = SessionGuard.EnsureAdmin(session).GetReservationsCountByProducts(list, licId);
            else
                dict = SessionGuard.EnsureAdmin(session).GetReservationsCountByProducts(list);

            var res = new List<ServerAdmin.Models.ReservationCountInfo>();
            foreach (var kv in dict)
                res.Add(new ServerAdmin.Models.ReservationCountInfo
                {
                    ProductId = kv.Key,
                    Count = kv.Value
                });
            return res;
        }
    }
}

