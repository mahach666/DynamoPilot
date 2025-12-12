using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;

namespace Position
{
    /// <summary>
    /// Ноды для получения свойств должностей в системе Pilot
    /// </summary>
    public static class Properties
    {
        /// <summary>
        /// Получает порядок должности
        /// </summary>
        /// <param name="pPosition">Должность</param>
        /// <returns>Порядок должности</returns>
        [IsDesignScriptCompatible]
        public static int GetOrder(PPosition pPosition) => pPosition.Order;

        /// <summary>
        /// Получает идентификатор должности
        /// </summary>
        /// <param name="pPosition">Должность</param>
        /// <returns>Идентификатор должности</returns>
        [IsDesignScriptCompatible]
        public static int GetPosition(PPosition pPosition) => pPosition.Position;
    }
}
