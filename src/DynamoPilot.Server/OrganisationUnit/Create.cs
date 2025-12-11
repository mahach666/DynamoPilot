using System;
using System.Collections.Generic;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace SOrganisationUnit
{
    /// <summary>
    /// Узлы для создания организационной единицы через ServerAdminApi (ChangeOrganisationUnits).
    /// </summary>
    [NodeCategory("Pilot.Server.OrganisationUnit")]
    [NodeDescription("Создание орг. единицы (админ API)")]
    public static class Create
    {
        /// <summary>
        /// Создает новую организационную единицу и применяет изменения.
        /// </summary>
        [NodeName("CreateOrganisationUnit")]
        [IsDesignScriptCompatible]
        public static DOrgStructureChangeResult CreateOrganisationUnit(
            ServerAdminSession session,
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
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Название обязательно", nameof(title));

            var guardedSession = SessionGuard.EnsureAdminSession(session);
            var databaseName = guardedSession.DatabaseName;

            var newUnit = new DOrganisationUnit
            {
                Id = id,
                Title = title,
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

            var change = new DOrganisationUnitChangeData(null, newUnit);
            var changeset = new DOrganisationUnitChangeset(change);

            return guardedSession.ServerAdminApi.ChangeOrganisationUnits(databaseName, changeset);
        }
    }
}

