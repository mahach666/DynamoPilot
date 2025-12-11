using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace SOrganisationUnit
{
    /// <summary>
    /// Узлы для изменения организационных единиц.
    /// </summary>
    [NodeCategory("Pilot.Server.OrganisationUnit")]
    [NodeDescription("Обновление данных организационной единицы")]
    public static class Edit
    {
        [NodeName("UpdateOrganisationUnit")]
        [IsDesignScriptCompatible]
        public static void UpdateOrganisationUnit(ServerSession session, DOrganisationUnitUpdateInfo updateInfo)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            srv.UpdateOrganisationUnit(updateInfo);
        }
    }
}

