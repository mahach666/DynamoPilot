using System;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace Admin.People
{
    /// <summary>
    /// Создание/обновление пользователей через ServerAdminApi.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.People")]
    [NodeDescription("Создание/обновление пользователей через ServerAdminApi")]
    public static class Change
    {
        [NodeName("ChangePeople")]
        [IsDesignScriptCompatible]
        public static DOrgStructureChangeResult ChangePeople(ServerAdminSession session, DPersonChangeset changeset)
        {
            if (changeset == null)
                throw new ArgumentNullException(nameof(changeset));

            var guardedSession = SessionGuard.EnsureAdminSession(session);
            var databaseName = guardedSession.DatabaseName;

            return guardedSession.ServerAdminApi.ChangePeople(databaseName, changeset);
        }
    }
}

