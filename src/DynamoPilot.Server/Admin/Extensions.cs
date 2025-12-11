using System.Collections.Generic;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace ServerAdminExtensions
{
    /// <summary>
    /// Работа с расширениями и маппингами AD.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.Extensions")]
    [NodeDescription("Расширения сервера и AD mapping через ServerAdminApi")]
    public static class Extensions
    {
        [NodeName("ListExtensions")]
        [IsDesignScriptCompatible]
        public static IList<ServerExtensionInfo> ListExtensions(ServerAdminSession session)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.ListExtensions() ?? new List<ServerExtensionInfo>();
        }

        [NodeName("SetActiveDirectoryAttributesMapping")]
        [IsDesignScriptCompatible]
        public static void SetActiveDirectoryAttributesMapping(ServerAdminSession session, ActiveDirectoryAttributesMapping mapping)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.SetActiveDirectoryAttributesMapping(mapping);
        }

        [NodeName("GetActiveDirectoryAttributesMapping")]
        [IsDesignScriptCompatible]
        public static ActiveDirectoryAttributesMapping GetActiveDirectoryAttributesMapping(ServerAdminSession session)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.GetActiveDirectoryAttributesMapping();
        }
    }
}

