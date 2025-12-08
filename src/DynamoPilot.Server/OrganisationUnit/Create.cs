using Ascon.Pilot.DataClasses;
using Ascon.Pilot.Server.Api.Contracts;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;
using System;
using System.Collections.Generic;

namespace ServerOrganisationUnit
{
    /// <summary>
    /// Узлы для создания и изменения орг. единиц через Admin API.
    /// </summary>
    [NodeCategory("Pilot.Server.OrganisationUnit.Create")]
    [NodeDescription("Создание и изменения оргструктуры")]
    public static class Create
    {
        [NodeName("ChangeOrganisationUnits")]
        [IsDesignScriptCompatible]
        public static DOrgStructureChangeResult ChangeOrganisationUnits(
            ServerSession session,
            string databaseName,
            DOrganisationUnitChangeset changeset)
        {
            var admin = SessionGuard.EnsureAdmin(session);
            return admin.ChangeOrganisationUnits(databaseName, changeset);
        }

        [NodeName("CreateOrganisationUnit")]
        [IsDesignScriptCompatible]
        public static DOrgStructureChangeResult CreateOrganisationUnit(
            ServerSession session,
            string databaseName,
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
            var newUnit = ChangeData.MakeNewUnit(
                id,
                title,
                kind,
                isBoss,
                isDeleted,
                isCanceled,
                person,
                children,
                vicePersons,
                groupPersons);

            var change = ChangeData.MakeChangeData(null, newUnit);
            var changeset = ChangeData.MakeChangeset(new[] { change });

            var admin = SessionGuard.EnsureAdmin(session);
            return admin.ChangeOrganisationUnits(databaseName, changeset);
        }
    }
}

