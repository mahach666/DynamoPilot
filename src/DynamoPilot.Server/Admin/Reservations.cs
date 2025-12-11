using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServerAdmin.Reservations
{
    /// <summary>
    /// Чтение резерваций.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.Reservations")]
    [NodeDescription("Получение резерваций через ServerAdminApi")]
    public static class Get
    {
        [NodeName("GetReservations")]
        [IsDesignScriptCompatible]
        public static IList<DReservation> GetReservations(ServerAdminSession session)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.GetReservations()?.ToList() ?? new List<DReservation>();
        }

        [NodeName("GetReservationsCountByProducts")]
        [IsDesignScriptCompatible]
        public static IDictionary<int, int> GetReservationsCountByProducts(ServerAdminSession session, IEnumerable<int> products)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.GetReservationsCountByProducts(products ?? Array.Empty<int>()) ?? new Dictionary<int, int>();
        }
    }

    /// <summary>
    /// Изменение резерваций.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.Reservations")]
    [NodeDescription("Изменение резерваций через ServerAdminApi")]
    public static class Edit
    {
        [NodeName("UpdateReservations")]
        [IsDesignScriptCompatible]
        public static void UpdateReservations(ServerAdminSession session, DReservation value)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.UpdateReservations(value);
        }

        [NodeName("DeleteReservationByDatabaseId")]
        [IsDesignScriptCompatible]
        public static void DeleteReservationByDataBaseId(ServerAdminSession session, Guid databaseId)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.DeleteReservationByDataBaseId(databaseId);
        }

        [NodeName("DeleteReservationById")]
        [IsDesignScriptCompatible]
        public static void DeleteReservationById(ServerAdminSession session, Guid id)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.DeleteReservationById(id);
        }

        [NodeName("DeleteReservationByOrUnitId")]
        [IsDesignScriptCompatible]
        public static void DeleteReservationByOrUnitId(ServerAdminSession session, Guid databaseId, int orgUnitId)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.DeleteReservationByOrUnitId(databaseId, orgUnitId);
        }
    }
}

