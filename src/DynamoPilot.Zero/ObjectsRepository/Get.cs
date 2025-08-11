using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;

namespace ObjectsRepository
{
    /// <summary>
    /// Ноды для выбора и получения репозитория объектов в системе Pilot
    /// </summary>
    public static class Get
    {
        /// <summary>
        /// Получить экземпляр ObjectsRepository
        /// </summary>
        /// <returns>PObjectsRepository</returns>
        [IsDesignScriptCompatible]
        public static PObjectsRepository GetObjectsRepository()
        {
            return StaticMetadata.ObjectsRepository;
        }
    }
}