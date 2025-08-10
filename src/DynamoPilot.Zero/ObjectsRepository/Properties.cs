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

        [IsDesignScriptCompatible]
        public static IEnumerable<PStorageDataObject> GetStorageObjects(PObjectsRepository objectsRepository,
            IEnumerable<string> paths)
        {
            return objectsRepository.GetStorageObjects(paths);
        }

        [IsDesignScriptCompatible]
        public static string GetStoragePath(PObjectsRepository objectsRepository)
        {
            return objectsRepository.GetStoragePath();
        }

        [IsDesignScriptCompatible]
        public static string GetStoragePath(PObjectsRepository objectsRepository, Guid objId)
        {
            return objectsRepository.GetStoragePath(objId);
        }       

        [IsDesignScriptCompatible]
        public static void Mount(PObjectsRepository objectsRepository, Guid objId)
        {
            objectsRepository.Mount(objId);
        }
    }
} 