using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System.Collections.Generic;

namespace Person
{
    public static class Select
    {
        /// <summary>
        /// Получает список всех пользователей
        /// </summary>
        /// <returns>Коллекция пользователей</returns>
        [IsDesignScriptCompatible]
        public static IEnumerable<PPerson> GetPeople()
        {
            return StaticMetadata.ObjectsRepository.GetPeople();
        }

        /// <summary>
        /// Получает пользователя по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Пользователь</returns>
        [IsDesignScriptCompatible]
        public static PPerson GetPerson(int id)
        {
            return StaticMetadata.ObjectsRepository.GetPerson(id);
        }

        /// <summary>
        /// Получает текущего пользователя
        /// </summary>
        /// <returns>Текущий пользователь</returns>
        [IsDesignScriptCompatible]
        public static PPerson GetCurrentPerson()
        {
            return StaticMetadata.ObjectsRepository.GetCurrentPerson();
        }
    }
}
