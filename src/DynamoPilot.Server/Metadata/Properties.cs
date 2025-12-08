using System.Collections.Generic;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace ServerMetadata
{
    /// <summary>
    /// Узлы для получения свойств метаданных (DMetadata).
    /// </summary>
    [NodeCategory("Pilot.Server.Metadata.Properties")]
    [NodeDescription("Доступ к полям метаданных базы")]
    public static class Properties
    {
        [NodeName("Version")]
        [IsDesignScriptCompatible]
        public static long GetVersion(DMetadata metadata) => metadata.Version;

        [NodeName("Types")]
        [IsDesignScriptCompatible]
        public static IList<MType> GetTypes(DMetadata metadata) => metadata.Types;

        [NodeName("UserStates")]
        [IsDesignScriptCompatible]
        public static IList<MUserState> GetUserStates(DMetadata metadata) => metadata.UserStates;

        [NodeName("StateMachines")]
        [IsDesignScriptCompatible]
        public static IList<MUserStateMachine> GetStateMachines(DMetadata metadata) => metadata.StateMachines;

        [NodeName("AutomationConfig")]
        [IsDesignScriptCompatible]
        public static IList<AutomationScript> GetAutomationConfig(DMetadata metadata) => metadata.AutomationConfig;
    }
}

