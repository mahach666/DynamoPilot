using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System;

namespace ObjectsRepository
{
    /// <summary>
    /// Ноды для получения свойств репозитория объектов в системе Pilot
    /// </summary>
    public static class Properties
    {
        /// <summary>
        /// Получает идентификатор базы данных
        /// </summary>
        /// <param name="objectsRepository">Репозиторий объектов</param>
        /// <returns>Идентификатор базы данных</returns>
        [IsDesignScriptCompatible]
        public static Guid GetDatabaseId(PObjectsRepository objectsRepository)
        {
            return objectsRepository.GetDatabaseId();
        }

        /// <summary>
        /// Получает путь к хранилищу
        /// </summary>
        /// <param name="objectsRepository">Репозиторий объектов</param>
        /// <returns>Путь к хранилищу</returns>
        [IsDesignScriptCompatible]
        public static string GetStoragePath(PObjectsRepository objectsRepository)
        {
            return objectsRepository.GetStoragePath();
        }
    }
}