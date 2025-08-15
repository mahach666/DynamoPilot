using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System;
using System.Collections.Generic;

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
        /// Получает объекты хранилища по списку путей
        /// </summary>
        /// <param name="objectsRepository">Репозиторий объектов</param>
        /// <param name="paths">Список путей</param>
        /// <returns>Коллекция объектов хранилища</returns>
        [IsDesignScriptCompatible]
        public static IEnumerable<PStorageDataObject> GetStorageObjects(PObjectsRepository objectsRepository,
            IEnumerable<string> paths)
        {
            return objectsRepository.GetStorageObjects(paths);
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

        /// <summary>
        /// Получает путь к хранилищу объекта
        /// </summary>
        /// <param name="objectsRepository">Репозиторий объектов</param>
        /// <param name="objId">Идентификатор объекта</param>
        /// <returns>Путь к хранилищу объекта</returns>
        [IsDesignScriptCompatible]
        public static string GetStoragePath(PObjectsRepository objectsRepository, Guid objId)
        {
            return objectsRepository.GetStoragePath(objId);
        }       

        /// <summary>
        /// Монтирует объект в файловую систему
        /// </summary>
        /// <param name="objectsRepository">Репозиторий объектов</param>
        /// <param name="objId">Идентификатор объекта для монтирования</param>
        [IsDesignScriptCompatible]
        public static void Mount(PObjectsRepository objectsRepository, Guid objId)
        {
            objectsRepository.Mount(objId);
        }
    }
} 