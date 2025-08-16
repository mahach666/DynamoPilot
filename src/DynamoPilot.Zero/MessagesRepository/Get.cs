using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;

namespace MessagesRepository
{
    public static class Get
    {
        /// <summary>
        /// Получить экземпляр MessagesRepository
        /// </summary>
        /// <returns>PMessagesRepository</returns>
        [IsDesignScriptCompatible]
        public static PMessagesRepository GetObjectsRepository()
        {
            return StaticMetadata.MessagesRepository;
        }
    }
}
