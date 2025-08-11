using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System.Collections.Generic;

namespace OrganisationUnit
{
    public static class Get
    {
        /// <summary>
        /// Получает организационное подразделение по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор подразделения</param>
        /// <returns>Организационное подразделение</returns>
        [IsDesignScriptCompatible]
        public static POrganisationUnit GetOrganisationUnit(int id)
        {
            return StaticMetadata.ObjectsRepository.GetOrganisationUnit(id);
        }

        /// <summary>
        /// Получает список всех организационных подразделений
        /// </summary>
        /// <returns>Коллекция организационных подразделений</returns>
        [IsDesignScriptCompatible]
        public static IEnumerable<POrganisationUnit> GetOrganisationUnits()
        {
            return StaticMetadata.ObjectsRepository.GetOrganisationUnits();
        }
    }
}
