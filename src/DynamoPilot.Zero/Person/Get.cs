using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using SharpDX.Win32;
using System.Collections.Generic;

namespace Person
{
    /// <summary>
    /// Ноды для выбора и получения пользователей в системе Pilot
    /// </summary>
    public static class Get
    {
        /// <summary>
        /// Получает список всех пользователей
        /// </summary>
        /// <returns>Коллекция пользователей</returns>
        [IsDesignScriptCompatible]
        public static IEnumerable<PPerson> GetAll()
        {
            return StaticMetadata.ObjectsRepository.GetPeople();
        }

        /// <summary>
        /// Получает пользователя по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Пользователь</returns>
        [IsDesignScriptCompatible]
        public static PPerson GetById(int id)
        {
            return StaticMetadata.ObjectsRepository.GetPerson(id);
        }

        /// <summary>
        /// Получает текущего пользователя
        /// </summary>
        /// <returns>Текущий пользователь</returns>
        [IsDesignScriptCompatible]
        public static PPerson GetCurrent()
        {
            return StaticMetadata.ObjectsRepository.GetCurrentPerson();
        }


        /// <summary>
        /// Получает пользователя по организационной единице (должности)
        /// </summary>
        /// <param name="pOrganisationUnit">Организационная единица</param>
        /// <returns>Пользователь, занимающий данную должность, или null</returns>
        [IsDesignScriptCompatible]
        public static PPerson GetByPosition(POrganisationUnit pOrganisationUnit)
        {
            var person = pOrganisationUnit.Person();
            if (pOrganisationUnit == null || person < 1)
                return null;

            return GetById(person);
        }

        /// <summary>
        /// Получает пользователя по идентификатору должности
        /// </summary>
        /// <param name="id">Идентификатор должности</param>
        /// <returns>Пользователь, занимающий данную должность, или null</returns>
        [IsDesignScriptCompatible]
        public static PPerson GetByPositionId(int id)
        {
            var orgUnit = OrganisationUnit.Get.GetOrganisationUnit(id);

            if (orgUnit == null)
                return null;

            return GetByPosition(orgUnit);
        }
    }
}
