using System.Collections.Generic;
using System.Linq;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace SHistoryItem
{
    /// <summary>
    /// Узлы для получения истории объектов.
    /// </summary>
    [NodeCategory("Pilot.Server.History")]
    [NodeDescription("Загрузка элементов истории по GUID")]
    public static class Get
    {
        [NodeName("GetHistoryItems")]
        [IsDesignScriptCompatible]
        public static IList<DHistoryItem> GetHistoryItems(ServerSession session, IList<string> ids)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            var guidIds = SessionGuard.ParseGuids(ids ?? System.Array.Empty<string>());
            return guidIds.Length == 0
                ? new List<DHistoryItem>()
                : srv.GetHistoryItems(guidIds).ToList();
        }
    }
}

