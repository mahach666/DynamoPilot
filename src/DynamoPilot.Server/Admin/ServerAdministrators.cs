using System.Collections.Generic;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;
using System.Linq;

namespace ServerAdminAdmins
{
    /// <summary>
    /// Управление администраторами сервера.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.Administrators")]
    [NodeDescription("Создание и управление учетками администраторов сервера")]
    public static class ServerAdministrators
    {
        [NodeName("GetServerAdministrators")]
        [IsDesignScriptCompatible]
        public static IList<DServerAdministrator> GetServerAdministrators(ServerAdminSession session)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.GetServerAdministrators()?.ToList() ?? new List<DServerAdministrator>();
        }

        [NodeName("CreateServerAdministrator")]
        [IsDesignScriptCompatible]
        public static void CreateServerAdministrator(ServerAdminSession session, DServerAdministrator admin, string protectedPassword)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.CreateServerAdministrator(admin, protectedPassword);
        }

        [NodeName("UpdateServerAdministrator")]
        [IsDesignScriptCompatible]
        public static void UpdateServerAdministrator(ServerAdminSession session, DServerAdministrator admin, string protectedPassword)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.UpdateServerAdministrator(admin, protectedPassword);
        }

        [NodeName("DeleteServerAdministrator")]
        [IsDesignScriptCompatible]
        public static void DeleteServerAdministrator(ServerAdminSession session, DServerAdministrator admin)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.DeleteServerAdministrator(admin);
        }
    }
}

