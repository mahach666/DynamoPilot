using System;
using System.Collections.Generic;
using System.Linq;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace ServerOrganisationUnit
{
    /// <summary>
    /// Узлы для формирования данных изменений организационных единиц.
    /// </summary>
    [NodeCategory("Pilot.Server.OrganisationUnit")]
    [NodeDescription("Формирование DOrganisationUnitChangeData и Changeset")]
    public static class ChangeData
    {
        [NodeName("CreateOrganisationUnitChangeData")]
        [IsDesignScriptCompatible]
        public static DOrganisationUnitChangeData CreateOrganisationUnitChangeData(DOrganisationUnit oldUnit, DOrganisationUnit newUnit)
        {
            if (oldUnit == null)
                throw new ArgumentNullException(nameof(oldUnit));
            if (newUnit == null)
                throw new ArgumentNullException(nameof(newUnit));

            return new DOrganisationUnitChangeData(oldUnit, newUnit);
        }

        [NodeName("CreateOrganisationUnitChangeset")]
        [IsDesignScriptCompatible]
        public static DOrganisationUnitChangeset CreateOrganisationUnitChangeset(IList<DOrganisationUnitChangeData> changes)
        {
            var array = changes?.ToArray() ?? Array.Empty<DOrganisationUnitChangeData>();
            return new DOrganisationUnitChangeset(array);
        }
    }
}
