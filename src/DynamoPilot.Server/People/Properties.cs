using System.Collections.Generic;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace ServerPeople
{
    /// <summary>
    /// Узлы для получения свойств пользователя (DPerson) из серверного API.
    /// </summary>
    [NodeCategory("Pilot.Server.People.Properties")]
    [NodeDescription("Доступ к полям пользователя")]
    public static class Properties
    {
        [NodeName("Id")]
        [IsDesignScriptCompatible]
        public static int GetId(DPerson person) => person.Id;

        [NodeName("Login")]
        [IsDesignScriptCompatible]
        public static string GetLogin(DPerson person) => person.Login;

        [NodeName("DisplayName")]
        [IsDesignScriptCompatible]
        public static string GetDisplayName(DPerson person) => person.DisplayName;

        [NodeName("Comment")]
        [IsDesignScriptCompatible]
        public static string GetComment(DPerson person) => person.Comment;

        [NodeName("Sid")]
        [IsDesignScriptCompatible]
        public static string GetSid(DPerson person) => person.Sid;

        [NodeName("UidDn")]
        [IsDesignScriptCompatible]
        public static string GetUidDn(DPerson person) => person.UidDn;

        [NodeName("Email")]
        [IsDesignScriptCompatible]
        public static string GetEmail(DPerson person) => person.Email;

        [NodeName("Phone")]
        [IsDesignScriptCompatible]
        public static string GetPhone(DPerson person) => person.Phone;

        [NodeName("AllowedIp")]
        [IsDesignScriptCompatible]
        public static string GetAllowedIp(DPerson person) => person.AllowedIp;

        [NodeName("IsDeleted")]
        [IsDesignScriptCompatible]
        public static bool GetIsDeleted(DPerson person) => person.IsDeleted;

        [NodeName("IsAdmin")]
        [IsDesignScriptCompatible]
        public static bool GetIsAdmin(DPerson person) => person.IsAdmin;

        [NodeName("IsInactive")]
        [IsDesignScriptCompatible]
        public static bool GetIsInactive(DPerson person) => person.IsInactive;

        [NodeName("AccountState")]
        [IsDesignScriptCompatible]
        public static AccountStates GetAccountState(DPerson person) => person.AccountState;

        [NodeName("Positions")]
        [IsDesignScriptCompatible]
        public static IList<int> GetPositions(DPerson person) => person.Positions;

        [NodeName("BossOf")]
        [IsDesignScriptCompatible]
        public static IList<int> GetBossOf(DPerson person) => person.BossOf;

        [NodeName("Groups")]
        [IsDesignScriptCompatible]
        public static IList<int> GetGroups(DPerson person) => person.Groups;

        [NodeName("AllOrgUnits")]
        [IsDesignScriptCompatible]
        public static IEnumerable<int> GetAllOrgUnits(DPerson person) => person.AllOrgUnits;
    }
}

