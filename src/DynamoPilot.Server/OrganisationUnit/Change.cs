using System;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace ServerOrganisationUnit
{
    /// <summary>
    /// Узлы для создания и обновления организационных единиц через административное API.
    /// </summary>
    [NodeCategory("Pilot.Server.OrganisationUnit")]
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
            var databaseName = guardedSession.Credentials.DatabaseName;

            if (string.IsNullOrWhiteSpace(databaseName))
                throw new InvalidOperationException("Имя базы данных не определено для вызова ServerAdminApi.");

            return guardedSession.ServerAdminApi.ChangeOrganisationUnits(databaseName, changeset);
        }
    }
}

