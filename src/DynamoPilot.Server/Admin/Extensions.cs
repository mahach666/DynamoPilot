using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;
using System.Collections.Generic;

namespace ServerAdmin.Extensions
{
    /// <summary>
    /// Чтение расширений и AD mapping.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.Extensions")]
    [NodeDescription("Чтение расширений и AD mapping через ServerAdminApi")]
    public static class Get
    {
        [NodeName("ListExtensions")]
        [IsDesignScriptCompatible]
        public static IList<ServerExtensionInfo> ListExtensions(ServerAdminSession session)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.ListExtensions() ?? new List<ServerExtensionInfo>();
        }

        [NodeName("GetActiveDirectoryAttributesMapping")]
        [IsDesignScriptCompatible]
        public static ActiveDirectoryAttributesMapping GetActiveDirectoryAttributesMapping(ServerAdminSession session)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.GetActiveDirectoryAttributesMapping();
        }
    }

    /// <summary>
    /// Изменение AD mapping.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.Extensions")]
    [NodeDescription("Изменение AD mapping через ServerAdminApi")]
    public static class Edit
    {
        [NodeName("SetActiveDirectoryAttributesMapping")]
        [IsDesignScriptCompatible]
        public static void SetActiveDirectoryAttributesMapping(ServerAdminSession session, ActiveDirectoryAttributesMapping mapping)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.SetActiveDirectoryAttributesMapping(mapping);
        }
    }
}

