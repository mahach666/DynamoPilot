using System;
using System.Collections.Generic;
using System.Linq;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace ServerOrganisationUnit
{
    /// <summary>
    /// Узлы для сборки изменений оргструктуры (DOrganisationUnitChangeset).
    /// </summary>
    [NodeCategory("Pilot.Server.OrganisationUnit.Change")]
    [NodeDescription("Конструкторы изменений оргструктуры")]
    public static class ChangeData
    {
        [NodeName("MakeChangeData")]
        [IsDesignScriptCompatible]
        public static DOrganisationUnitChangeData MakeChangeData(DOrganisationUnit oldUnit, DOrganisationUnit newUnit)
        {
            return new DOrganisationUnitChangeData(oldUnit, newUnit);
        }

        [NodeName("MakeChangeset")]
        [IsDesignScriptCompatible]
        public static DOrganisationUnitChangeset MakeChangeset(IList<DOrganisationUnitChangeData> changes)
        {
            return changes == null
                ? new DOrganisationUnitChangeset()
                : new DOrganisationUnitChangeset(changes.ToArray());
        }

        [NodeName("MakeNewUnit")]
        [IsDesignScriptCompatible]
        public static DOrganisationUnit MakeNewUnit(
            int id,
            string title,
            OrgUnitKind kind,
            bool isBoss = false,
            bool isDeleted = false,
            bool isCanceled = false,
            int person = -1,
            IList<int> children = null,
            IList<int> vicePersons = null,
            IList<int> groupPersons = null)
        {
            var unit = new DOrganisationUnit
            {
                Id = id,
                Title = title ?? string.Empty,
                Kind = kind,
                IsBoss = isBoss,
                IsDeleted = isDeleted,
                IsCanceled = isCanceled,
                Person = person
            };

            if (children != null)
                unit.Children.AddRange(children);
            if (vicePersons != null)
                unit.VicePersons.AddRange(vicePersons);
            if (groupPersons != null)
                unit.GroupPersons.AddRange(groupPersons);

            return unit;
        }
    }
}

