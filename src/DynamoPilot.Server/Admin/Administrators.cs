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
    /// Управление серверными администраторами.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.Administrators")]
    [NodeDescription("CRUD для серверных администраторов")]
    public static class Administrators
    {
        [NodeName("GetAdministrators")]
        [IsDesignScriptCompatible]
        public static IEnumerable<DServerAdministrator> GetAdministrators(ServerSession session)
        {
            return SessionGuard.EnsureAdmin(session).GetServerAdministrators();
        }

        [NodeName("CreateAdministrator")]
        [IsDesignScriptCompatible]
        public static void CreateAdministrator(ServerSession session, DServerAdministrator admin, string protectedPassword)
        {
            SessionGuard.EnsureAdmin(session).CreateServerAdministrator(admin, protectedPassword);
        }

        [NodeName("UpdateAdministrator")]
        [IsDesignScriptCompatible]
        public static void UpdateAdministrator(ServerSession session, DServerAdministrator admin, string protectedPassword)
        {
            SessionGuard.EnsureAdmin(session).UpdateServerAdministrator(admin, protectedPassword);
        }

        [NodeName("DeleteAdministrator")]
        [IsDesignScriptCompatible]
        public static void DeleteAdministrator(ServerSession session, DServerAdministrator admin)
        {
            SessionGuard.EnsureAdmin(session).DeleteServerAdministrator(admin);
        }
    }
}

