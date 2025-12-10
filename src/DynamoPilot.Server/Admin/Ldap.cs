using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascon.Pilot.DataClasses;
using Ascon.Pilot.Server.Api.Contracts;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace ServerAdmin
{
    /// <summary>
    /// LDAP и Active Directory операции.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.Ldap")]
    [NodeDescription("Работа с LDAP/AD пользователями и настройками")]
    public static class Ldap
    {
        [NodeName("SetLdapServer")]
        [IsDesignScriptCompatible]
        public static void SetLdapServer(ServerSession session, string url, bool enableSsl, string sslThumbprint, bool useVlv, string username, string password, LdapParameters ldapParameters)
        {
            SessionGuard.EnsureAdmin(session).SetLdapServer(url, enableSsl, sslThumbprint, useVlv, username, password, ldapParameters);
        }

        [NodeName("GetLdapServer")]
        [IsDesignScriptCompatible]
        public static LdapServer GetLdapServer(ServerSession session)
        {
            return SessionGuard.EnsureAdmin(session).GetLdapServer();
        }

        [NodeName("GetDomains")]
        [IsDesignScriptCompatible]
        public static List<string> GetDomains(ServerSession session)
        {
            return SessionGuard.EnsureAdmin(session).GetDomains().ToList();
        }

        [NodeName("GetAdUsers")]
        [IsDesignScriptCompatible]
        public static List<AdUser> GetAdUsers(ServerSession session, string domainName, string searchRequest)
        {
            return SessionGuard.EnsureAdmin(session).GetAdUsers(domainName, searchRequest).ToList();
        }

        [NodeName("GetAdUser")]
        [IsDesignScriptCompatible]
        public static AdUser GetAdUser(ServerSession session, string sid, string domainName)
        {
            return SessionGuard.EnsureAdmin(session).GetAdUser(sid, domainName);
        }

        [NodeName("GetLdapUsers")]
        [IsDesignScriptCompatible]
        public static List<LdapUser> GetLdapUsers(ServerSession session, string searchRequest)
        {
            return SessionGuard.EnsureAdmin(session).GetLdapUsersAsync(searchRequest).Result.ToList();
        }

        [NodeName("GetLdapUser")]
        [IsDesignScriptCompatible]
        public static LdapUser GetLdapUser(ServerSession session, string userId)
        {
            return SessionGuard.EnsureAdmin(session).GetLdapUserAsync(userId).Result;
        }

        [NodeName("ImportLdapPerson")]
        [IsDesignScriptCompatible]
        public static DPerson ImportLdapPerson(ServerSession session, string ldapLogin)
        {
            return SessionGuard.EnsureAdmin(session).ImportLdapPersonAsync(ldapLogin).Result;
        }

        [NodeName("ImportAdPerson")]
        [IsDesignScriptCompatible]
        public static DPerson ImportAdPerson(ServerSession session, string sid, string domainName)
        {
            return SessionGuard.EnsureAdmin(session).ImportAdPerson(sid, domainName);
        }

        [NodeName("SyncPeople")]
        [IsDesignScriptCompatible]
        public static void SyncPeople(ServerSession session, List<DPerson> personsForSync)
        {
            SessionGuard.EnsureAdmin(session).SyncPeople(personsForSync ?? new List<DPerson>());
        }

        [NodeName("SetAdAttributesMapping")]
        [IsDesignScriptCompatible]
        public static void SetActiveDirectoryAttributesMapping(ServerSession session, ActiveDirectoryAttributesMapping mapping)
        {
            SessionGuard.EnsureAdmin(session).SetActiveDirectoryAttributesMapping(mapping);
        }

        [NodeName("GetAdAttributesMapping")]
        [IsDesignScriptCompatible]
        public static ActiveDirectoryAttributesMapping GetActiveDirectoryAttributesMapping(ServerSession session)
        {
            return SessionGuard.EnsureAdmin(session).GetActiveDirectoryAttributesMapping();
        }
    }
}

