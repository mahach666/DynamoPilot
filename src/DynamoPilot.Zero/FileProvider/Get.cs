using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;

namespace FileProvider
{
    /// <summary>
    /// Ноды для получения провайдера файлов Pilot
    /// </summary>
    public static class Get
    {
        /// <summary>
        /// Возвращает текущий провайдер файлов
        /// </summary>
        /// <returns>Экземпляр провайдера файлов</returns>
        [IsDesignScriptCompatible]
        public static PFileProvider GetFileProvider()
        {
            return StaticMetadata.FileProvider;
        }
    }
}
