using Ascon.Pilot.DataClasses;
using Ascon.Pilot.Server.Api.Contracts;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace ServerAdmin
{
    /// <summary>
    /// Импорт конфигурации метаданных.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.Import")]
    [NodeDescription("Импорт конфигурации метаданных")]
    public static class Import
    {
        [NodeName("ImportConfiguration")]
        [IsDesignScriptCompatible]
        public static DImportConfiguration ImportConfiguration(ServerSession session, DMetadata metadata, string databaseName)
        {
            return SessionGuard.EnsureAdmin(session).ImportConfiguration(metadata, databaseName);
        }
    }
}

