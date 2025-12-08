using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace ServerSettings
{
    /// <summary>
    /// Узлы для работы с настройками базы.
    /// </summary>
    [NodeCategory("Pilot.Server.Settings")]
    [NodeDescription("Получение и изменение настроек базы Pilot")]
    public static class Edit
    {
        [NodeName("GetPersonalSettings")]
        [IsDesignScriptCompatible]
        public static DSettings GetPersonalSettings(ServerSession session)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            return srv.GetPersonalSettings();
        }

        [NodeName("GetCommonSettings")]
        [IsDesignScriptCompatible]
        public static DSettings GetCommonSettings(ServerSession session)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            return srv.GetCommonSettings();
        }

        [NodeName("ChangeSettings")]
        [IsDesignScriptCompatible]
        public static void ChangeSettings(ServerSession session, DSettingsChange change)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            srv.ChangeSettings(change);
        }
    }
}

