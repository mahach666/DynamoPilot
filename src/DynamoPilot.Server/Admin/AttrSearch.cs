using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace ServerAdmin
{
    /// <summary>
    /// Операции с индексом атрибутного поиска.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.AttrSearch")]
    [NodeDescription("Перестройка индекса поиска")]
    public static class AttrSearch
    {
        [NodeName("RebuildIndex")]
        [IsDesignScriptCompatible]
        public static void RebuildIndex(ServerSession session)
        {
            SessionGuard.EnsureAdmin(session).AttrSearchRebuildIndex();
        }
    }
}

