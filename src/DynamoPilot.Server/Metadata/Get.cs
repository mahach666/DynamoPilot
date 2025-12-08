using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace ServerMetadata
{
    /// <summary>
    /// Узлы для получения метаданных через серверное API.
    /// </summary>
    [NodeCategory("Pilot.Server.Metadata")]
    [NodeDescription("Получение метаданных базы Pilot")]
    public static class Get
    {
        /// <summary>
        /// Возвращает текущие метаданные из сессии, при отсутствии запрашивает у сервера.
        /// </summary>
        [NodeName("GetMetadata")]
        [IsDesignScriptCompatible]
        public static DMetadata GetMetadata(ServerSession session)
        {
            var ensured = SessionGuard.EnsureSession(session);
            if (ensured.Metadata != null)
                return ensured.Metadata;

            ensured.Metadata = ensured.ServerApi.GetMetadata(0);
            return ensured.Metadata;
        }

        /// <summary>
        /// Обновляет метаданные, запрашивая версию новее localVersion.
        /// </summary>
        [NodeName("RefreshMetadata")]
        [IsDesignScriptCompatible]
        public static DMetadata RefreshMetadata(ServerSession session, long localVersion = 0)
        {
            var ensured = SessionGuard.EnsureSession(session);
            ensured.Metadata = ensured.ServerApi.GetMetadata(localVersion);
            return ensured.Metadata;
        }
    }
}

