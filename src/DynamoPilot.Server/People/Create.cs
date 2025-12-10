using System;
using System.Collections.Generic;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace ServerPeople
{
    /// <summary>
    /// Узлы для создания пользователя через ServerAdminApi.
    /// </summary>
    [NodeCategory("Pilot.Server.People")]
    [NodeDescription("Создание пользователя (админ API)")]
    public static class Create
    {
        /// <summary>
        /// Создает пользователя с указанными полями. Пароль ожидается в зашифрованном виде.
        /// </summary>
        [NodeName("CreatePerson")]
        [IsDesignScriptCompatible]
        public static DPerson CreatePerson(
            ServerAdminSession session,
            string login,
            string displayName,
            string encryptedPassword,
            string email = null,
            bool isAdmin = false,
            bool isInactive = false,
            string sid = null,
            string phone = null,
            string comment = null,
            string allowedIp = null,
            IList<int> positions = null,
            IList<int> groups = null,
            IList<int> bossOf = null,
            IList<int> allOrgUnits = null)
        {
            if (string.IsNullOrWhiteSpace(login))
                throw new ArgumentException("Логин обязателен", nameof(login));
            if (string.IsNullOrWhiteSpace(displayName))
                throw new ArgumentException("Отображаемое имя обязательно", nameof(displayName));

            var guardedSession = SessionGuard.EnsureAdminSession(session);
            var databaseName = guardedSession.DatabaseName;

            var person = new DPerson
            {
                Login = login,
                DisplayName = displayName,
                Email = email ?? string.Empty,
                IsAdmin = isAdmin,
                IsInactive = isInactive,
                Sid = sid,
                Phone = phone,
                Comment = comment ?? string.Empty,
                AllowedIp = allowedIp
            };

            if (positions != null)
                person.Positions.AddRange(positions);
            if (groups != null)
                person.Groups.AddRange(groups);
            if (bossOf != null)
                person.BossOf.AddRange(bossOf);
            if (allOrgUnits != null)
            {
                foreach (var id in allOrgUnits)
                    person.AllOrgUnits.Add(id);
            }

            var change = new DPersonChangeData(null, person, encryptedPassword);
            var changeset = new DPersonChangeset(change);
            var result = guardedSession.ServerAdminApi.ChangePeople(databaseName, changeset);
            var changed = result.ChangedPeople;
            return changed != null && changed.Count > 0 ? changed[0] : person;
        }
    }
}

