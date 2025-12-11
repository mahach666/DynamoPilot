using System;
using System.Collections.Generic;
using System.Linq;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace Admin.People
{
    /// <summary>
    /// Формирование DPersonChangeData/Changeset для admin API.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.People")]
    [NodeDescription("Формирование DPersonChangeData и DPersonChangeset (admin)")]
    public static class ChangeData
    {
        [NodeName("CreatePersonChangeData")]
        [IsDesignScriptCompatible]
        public static DPersonChangeData CreatePersonChangeData(DPerson oldPerson, DPerson newPerson, string newPasswordEncrypted = null)
        {
            if (oldPerson == null)
                throw new ArgumentNullException(nameof(oldPerson));
            if (newPerson == null)
                throw new ArgumentNullException(nameof(newPerson));

            if (string.IsNullOrWhiteSpace(newPasswordEncrypted))
                return new DPersonChangeData(oldPerson, newPerson);

            return new DPersonChangeData(oldPerson, newPerson, newPasswordEncrypted);
        }

        [NodeName("CreatePersonChangeset")]
        [IsDesignScriptCompatible]
        public static DPersonChangeset CreatePersonChangeset(IList<DPersonChangeData> changes)
        {
            var array = changes?.ToArray() ?? Array.Empty<DPersonChangeData>();
            return new DPersonChangeset(array);
        }

        [NodeName("BuildPersonChangeset")]
        [IsDesignScriptCompatible]
        public static DPersonChangeset BuildPersonChangeset(
            DPerson oldPerson,
            string login,
            string displayName,
            string email = null,
            bool isAdmin = false,
            bool isInactive = false,
            string sid = null,
            string phone = null,
            string comment = null,
            string allowedIp = null,
            string encryptedPassword = null,
            IList<int> positions = null,
            IList<int> groups = null,
            IList<int> bossOf = null,
            IList<int> allOrgUnits = null)
        {
            var newPerson = new DPerson
            {
                Login = login ?? string.Empty,
                DisplayName = displayName ?? string.Empty,
                Email = email ?? string.Empty,
                IsAdmin = isAdmin,
                IsInactive = isInactive,
                Sid = sid,
                Phone = phone,
                Comment = comment ?? string.Empty,
                AllowedIp = allowedIp
            };

            if (positions != null)
                newPerson.Positions.AddRange(positions);
            if (groups != null)
                newPerson.Groups.AddRange(groups);
            if (bossOf != null)
                newPerson.BossOf.AddRange(bossOf);
            if (allOrgUnits != null)
            {
                foreach (var id in allOrgUnits)
                    newPerson.AllOrgUnits.Add(id);
            }

            var change = CreatePersonChangeData(oldPerson, newPerson, encryptedPassword);
            return CreatePersonChangeset(new[] { change });
        }
    }
}

