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
        /// Получает текущего пользователя
        /// </summary>
        /// <param name="objectsRepository">Репозиторий объектов</param>
        /// <returns>Текущий пользователь</returns>
        [IsDesignScriptCompatible]
        public static PPerson GetCurrentPerson(PObjectsRepository objectsRepository)
        {
            return objectsRepository.GetCurrentPerson();
        }

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
        /// Получает организационное подразделение по идентификатору
        /// </summary>
        /// <param name="objectsRepository">Репозиторий объектов</param>
        /// <param name="id">Идентификатор подразделения</param>
        /// <returns>Организационное подразделение</returns>
        [IsDesignScriptCompatible]
        public static POrganisationUnit GetOrganisationUnit(PObjectsRepository objectsRepository, int id)
        {
            return objectsRepository.GetOrganisationUnit(id);
        }

        /// <summary>
        /// Получает список всех организационных подразделений
        /// </summary>
        /// <param name="objectsRepository">Репозиторий объектов</param>
        /// <returns>Коллекция организационных подразделений</returns>
        [IsDesignScriptCompatible]
        public static IEnumerable<POrganisationUnit> GetOrganisationUnits(PObjectsRepository objectsRepository)
        {
            return objectsRepository.GetOrganisationUnits();
        }

        /// <summary>
        /// Получает список всех пользователей
        /// </summary>
        /// <param name="objectsRepository">Репозиторий объектов</param>
        /// <returns>Коллекция пользователей</returns>
        [IsDesignScriptCompatible]
        public static IEnumerable<PPerson> GetPeople(PObjectsRepository objectsRepository)
        {
            return objectsRepository.GetPeople();
        }

        /// <summary>
        /// Получает пользователя по идентификатору
        /// </summary>
        /// <param name="objectsRepository">Репозиторий объектов</param>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Пользователь</returns>
        [IsDesignScriptCompatible]
        public static PPerson GetPerson(PObjectsRepository objectsRepository, int id)
        {
            return objectsRepository.GetPerson(id);
        }

        [IsDesignScriptCompatible]
        public static IEnumerable<PStorageDataObject> GetStorageObjects(PObjectsRepository objectsRepository, IEnumerable<string> paths)
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
        public static PType GetType(PObjectsRepository objectsRepository, int id)
        {
            return objectsRepository.GetType(id);
        }

        [IsDesignScriptCompatible]
        public static PType GetType(PObjectsRepository objectsRepository, string name)
        {
            return objectsRepository.GetType(name);
        }

        [IsDesignScriptCompatible]
        public static IEnumerable<PType> GetTypes(PObjectsRepository objectsRepository)
        {
            return objectsRepository.GetTypes();
        }

        //[IsDesignScriptCompatible]
        //public static Task<ServerCommandRequestResult> InvokeServerCommandAsync(PObjectsRepository objectsRepository, string commandName, byte[] data)
        //{
        //    return objectsRepository.InvokeServerCommandAsync(commandName, data);
        //}

        [IsDesignScriptCompatible]
        public static void Mount(PObjectsRepository objectsRepository, Guid objId)
        {
            objectsRepository.Mount(objId);
        }

        //[IsDesignScriptCompatible]
        //public static Task MountAsync(PObjectsRepository objectsRepository, Guid objId)
        //{
        //    return objectsRepository.MountAsync(objId);
        //}
    }
} 