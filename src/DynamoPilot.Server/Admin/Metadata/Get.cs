using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace Admin.Metadata
{
    /// <summary>
    /// Метаданные через ServerAdminApi.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.Metadata")]
    [NodeDescription("Получение и обновление метаданных через ServerAdminApi")]
    public static class Get
    {
        [NodeName("GetMetadataAdmin")]
        [IsDesignScriptCompatible]
        public static DMetadata GetMetadata(ServerAdminSession session)
        {
            var ensured = SessionGuard.EnsureAdminSession(session);
            if (ensured.Metadata != null)
                return ensured.Metadata;

            ensured.Metadata = ensured.ServerAdminApi.GetMetadata(0);
            return ensured.Metadata;
        }

        [NodeName("RefreshMetadataAdmin")]
        [IsDesignScriptCompatible]
        public static DMetadata RefreshMetadata(ServerAdminSession session, long localVersion = 0)
        {
            var ensured = SessionGuard.EnsureAdminSession(session);
            ensured.Metadata = ensured.ServerAdminApi.GetMetadata(localVersion);
            return ensured.Metadata;
        }

        [NodeName("UpdateMetadataAdmin")]
        [IsDesignScriptCompatible]
        public static long UpdateMetadata(ServerAdminSession session, DMetadata metadata)
        {
            var ensured = SessionGuard.EnsureAdminSession(session);
            return ensured.ServerAdminApi.UpdateMetadata(metadata);
        }
    }
}

