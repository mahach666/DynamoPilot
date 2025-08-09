using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;

namespace ObjectsRepository
{
    /// <summary>
    /// Ноды для выбора и получения репозитория объектов в системе Pilot
    /// </summary>
    public static class Select
    {
        /// <summary>
        /// Получить экземпляр ObjectsRepository
        /// </summary>
        /// <returns>PObjectsRepository</returns>
        [IsDesignScriptCompatible]
        public static PObjectsRepository Get()
        {
            return StaticMetadata.ObjectsRepository;
        }
    }
}