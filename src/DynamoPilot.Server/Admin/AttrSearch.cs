using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace ServerAdmin.AttrSearch
{
    /// <summary>
    /// Изменение индекса атрибутного поиска.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.Search")]
    [NodeDescription("Перестроение индекса атрибутного поиска через ServerAdminApi")]
    public static class Edit
    {
        [NodeName("AttrSearchRebuildIndex")]
        [IsDesignScriptCompatible]
        public static void AttrSearchRebuildIndex(ServerAdminSession session)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.AttrSearchRebuildIndex();
        }
    }
}

