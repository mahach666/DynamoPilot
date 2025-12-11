using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace SPeople
{
    /// <summary>
    /// Узлы для изменений пользователей.
    /// </summary>
    [NodeCategory("Pilot.Server.People")]
    [NodeDescription("Обновление данных пользователя")]
    public static class Edit
    {
        [NodeName("UpdatePerson")]
        [IsDesignScriptCompatible]
        public static void UpdatePerson(ServerSession session, DPersonUpdateInfo updateInfo)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            srv.UpdatePerson(updateInfo);
        }
    }
}

