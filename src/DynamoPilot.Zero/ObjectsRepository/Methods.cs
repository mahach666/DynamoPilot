using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System;
using System.Collections.Generic;

namespace ObjectsRepository
{
    public static class Methods
    {
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
        /// <returns>Ничего не возвращает</returns>
        [IsDesignScriptCompatible]
        public static void Mount(PObjectsRepository objectsRepository, Guid objId)
        {
            objectsRepository.Mount(objId);
        }
    }
}
