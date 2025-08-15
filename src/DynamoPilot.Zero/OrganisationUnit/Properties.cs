using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System.Collections.ObjectModel;

namespace OrganisationUnit
{
    /// <summary>
    /// Ноды для получения свойств организационных единиц в системе Pilot
    /// </summary>
    public static class Properties
    {
        /// <summary>
        /// Получает идентификатор организационной единицы
        /// </summary>
        /// <param name="pOrganisationUnit">Организационная единица</param>
        /// <returns>Идентификатор организационной единицы</returns>
        [IsDesignScriptCompatible]
        public static int GetId(POrganisationUnit pOrganisationUnit) => pOrganisationUnit.Id;

        /// <summary>
        /// Получает название организационной единицы
        /// </summary>
        /// <param name="pOrganisationUnit">Организационная единица</param>
        /// <returns>Название организационной единицы</returns>
        [IsDesignScriptCompatible]
        public static string GetTitle(POrganisationUnit pOrganisationUnit) => pOrganisationUnit.Title;

        /// <summary>
        /// Проверяет, удалена ли организационная единица
        /// </summary>
        /// <param name="pOrganisationUnit">Организационная единица</param>
        /// <returns>True, если организационная единица удалена</returns>
        [IsDesignScriptCompatible]
        public static bool GetIsDeleted(POrganisationUnit pOrganisationUnit) => pOrganisationUnit.IsDeleted;

        /// <summary>
        /// Получает список дочерних организационных единиц
        /// </summary>
        /// <param name="pOrganisationUnit">Организационная единица</param>
        /// <returns>Коллекция идентификаторов дочерних единиц</returns>
        [IsDesignScriptCompatible]
        public static ReadOnlyCollection<int> GetChildren(POrganisationUnit pOrganisationUnit) => pOrganisationUnit.Children;

        /// <summary>
        /// Проверяет, является ли организационная единица должностью
        /// </summary>
        /// <param name="pOrganisationUnit">Организационная единица</param>
        /// <returns>True, если это должность</returns>
        [IsDesignScriptCompatible]
        public static bool GetIsPosition(POrganisationUnit pOrganisationUnit) => pOrganisationUnit.IsPosition;

        /// <summary>
        /// Проверяет, является ли организационная единица руководящей должностью
        /// </summary>
        /// <param name="pOrganisationUnit">Организационная единица</param>
        /// <returns>True, если это руководящая должность</returns>
        [IsDesignScriptCompatible]
        public static bool GetIsChief(POrganisationUnit pOrganisationUnit) => pOrganisationUnit.IsChief;

        /// <summary>
        /// Получает идентификатор пользователя, занимающего должность
        /// </summary>
        /// <param name="pOrganisationUnit">Организационная единица</param>
        /// <returns>Идентификатор пользователя</returns>
        [IsDesignScriptCompatible]
        public static int Person(POrganisationUnit pOrganisationUnit) => pOrganisationUnit.Person();
    }
}
