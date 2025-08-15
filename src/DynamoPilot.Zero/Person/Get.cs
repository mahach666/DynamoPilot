using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using SharpDX.Win32;
using System.Collections.Generic;

namespace Person
{
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


        [IsDesignScriptCompatible]
        public static PPerson GetByPosition(POrganisationUnit pOrganisationUnit)
        {
            var person = pOrganisationUnit.Person();
            if (pOrganisationUnit == null || person < 1)
                return null;

            return GetById(person);
        }

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
