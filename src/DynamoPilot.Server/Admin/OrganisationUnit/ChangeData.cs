using System;
using System.Collections.Generic;
using System.Linq;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace Admin.OrganisationUnit
{
    /// <summary>
    /// Формирование изменений оргструктуры (admin).
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.OrganisationUnit")]
    [NodeDescription("Формирование DOrganisationUnitChangeData и Changeset (admin)")]
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

        [NodeName("BuildOrganisationUnitChangeset")]
        [IsDesignScriptCompatible]
        public static DOrganisationUnitChangeset BuildOrganisationUnitChangeset(
            DOrganisationUnit oldUnit,
            int id,
            string title,
            OrgUnitKind kind,
            int parentId = -1,
            int person = -1,
            bool isBoss = false,
            bool isDeleted = false,
            bool isCanceled = false,
            IList<int> children = null,
            IList<int> vicePersons = null,
            IList<int> permanentVicePersons = null,
            IList<int> groupPersons = null)
        {
            var newUnit = new DOrganisationUnit
            {
                Id = id,
                Title = title ?? string.Empty,
                Kind = kind,
                ParentId = parentId,
                Person = person,
                IsBoss = isBoss,
                IsDeleted = isDeleted,
                IsCanceled = isCanceled
            };

            if (children != null)
                newUnit.Children.AddRange(children);
            if (vicePersons != null)
                newUnit.VicePersons.AddRange(vicePersons);
            if (permanentVicePersons != null)
                newUnit.PermanentVicePersons.AddRange(permanentVicePersons);
            if (groupPersons != null)
                newUnit.GroupPersons.AddRange(groupPersons);

            var change = CreateOrganisationUnitChangeData(oldUnit, newUnit);
            return CreateOrganisationUnitChangeset(new[] { change });
        }
    }
}

