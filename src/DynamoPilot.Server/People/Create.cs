using Ascon.Pilot.DataClasses;
using Ascon.Pilot.Server.Api.Contracts;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;
using System.Collections.Generic;

namespace ServerPeople
{
    /// <summary>
    /// Узлы для создания и пакетного изменения пользователей через Admin API.
    /// </summary>
    [NodeCategory("Pilot.Server.People.Create")]
    [NodeDescription("Создание пользователей и применение changeset'ов")]
    public static class Create
    {
        [NodeName("CreatePerson")]
        [IsDesignScriptCompatible]
        public static DPerson CreatePerson(ServerSession session, DPerson person, string encryptedPassword)
        {
            var admin = SessionGuard.EnsureAdmin(session);
            return admin.CreatePerson(person, encryptedPassword);
        }

        [NodeName("ChangePeople")]
        [IsDesignScriptCompatible]
        public static DOrgStructureChangeResult ChangePeople(ServerSession session, string databaseName, DPersonChangeset changeset)
        {
            var admin = SessionGuard.EnsureAdmin(session);
            return admin.ChangePeople(databaseName, changeset);
        }

        [NodeName("CreatePersonWithPassword")]
        [IsDesignScriptCompatible]
        public static DOrgStructureChangeResult CreatePersonWithPassword(
            ServerSession session,
            string databaseName,
            DPerson person,
            string encryptedPassword)
        {
            var change = ChangeData.MakeChangeData(null, person, encryptedPassword);
            var changeset = ChangeData.MakeChangeset(new[] { change });
            var admin = SessionGuard.EnsureAdmin(session);
            return admin.ChangePeople(databaseName, changeset);
        }

        [NodeName("MakePerson")]
        [IsDesignScriptCompatible]
        public static DPerson MakePerson(
            int id,
            string login,
            string displayName,
            string comment = "",
            string sid = "",
            string uidDn = "",
            string email = "",
            string phone = "",
            string allowedIp = "",
            bool isDeleted = false,
            bool isAdmin = false,
            bool isInactive = false,
            AccountStates accountState = AccountStates.None,
            IList<int> positions = null,
            IList<int> bossOf = null,
            IList<int> groups = null,
            IList<int> allOrgUnits = null)
        {
            var p = new DPerson
            {
                Id = id,
                Login = login ?? string.Empty,
                DisplayName = displayName ?? string.Empty,
                Comment = comment ?? string.Empty,
                Sid = sid ?? string.Empty,
                UidDn = uidDn ?? string.Empty,
                Email = email ?? string.Empty,
                Phone = phone ?? string.Empty,
                AllowedIp = allowedIp ?? string.Empty,
                IsDeleted = isDeleted,
                IsAdmin = isAdmin,
                IsInactive = isInactive,
                AccountState = accountState
            };

            if (positions != null) p.Positions.AddRange(positions);
            if (bossOf != null) p.BossOf.AddRange(bossOf);
            if (groups != null) p.Groups.AddRange(groups);
            if (allOrgUnits != null) p.AllOrgUnits.UnionWith(allOrgUnits);

            return p;
        }
    }
}

