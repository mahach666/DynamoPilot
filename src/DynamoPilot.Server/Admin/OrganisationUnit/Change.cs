using System;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace Admin.OrganisationUnit
{
    /// <summary>
    /// Создание/обновление оргструктуры через ServerAdminApi.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.OrganisationUnit")]
    [NodeDescription("Создание/обновление оргструктуры через ServerAdminApi")]
    public static class Change
    {
        [NodeName("ChangeOrganisationUnits")]
        [IsDesignScriptCompatible]
        public static DOrgStructureChangeResult ChangeOrganisationUnits(ServerAdminSession session, DOrganisationUnitChangeset changeset)
        {
            if (changeset == null)
                throw new ArgumentNullException(nameof(changeset));

            var guardedSession = SessionGuard.EnsureAdminSession(session);
            var databaseName = guardedSession.DatabaseName;

            return guardedSession.ServerAdminApi.ChangeOrganisationUnits(databaseName, changeset);
        }
    }
}

