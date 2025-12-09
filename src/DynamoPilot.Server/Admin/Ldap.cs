using System.Collections.Generic;
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
        public static IEnumerable<string> GetDomains(ServerSession session)
        {
            return SessionGuard.EnsureAdmin(session).GetDomains();
        }

        [NodeName("GetAdUsers")]
        [IsDesignScriptCompatible]
        public static IEnumerable<AdUser> GetAdUsers(ServerSession session, string domainName, string searchRequest)
        {
            return SessionGuard.EnsureAdmin(session).GetAdUsers(domainName, searchRequest);
        }

        [NodeName("GetAdUser")]
        [IsDesignScriptCompatible]
        public static AdUser GetAdUser(ServerSession session, string sid, string domainName)
        {
            return SessionGuard.EnsureAdmin(session).GetAdUser(sid, domainName);
        }

        [NodeName("GetLdapUsers")]
        [IsDesignScriptCompatible]
        public static Task<IEnumerable<LdapUser>> GetLdapUsers(ServerSession session, string searchRequest)
        {
            return SessionGuard.EnsureAdmin(session).GetLdapUsersAsync(searchRequest);
        }

        [NodeName("GetLdapUser")]
        [IsDesignScriptCompatible]
        public static Task<LdapUser> GetLdapUser(ServerSession session, string userId)
        {
            return SessionGuard.EnsureAdmin(session).GetLdapUserAsync(userId);
        }

        [NodeName("ImportLdapPerson")]
        [IsDesignScriptCompatible]
        public static Task<DPerson> ImportLdapPerson(ServerSession session, string ldapLogin)
        {
            return SessionGuard.EnsureAdmin(session).ImportLdapPersonAsync(ldapLogin);
        }

        [NodeName("ImportAdPerson")]
        [IsDesignScriptCompatible]
        public static DPerson ImportAdPerson(ServerSession session, string sid, string domainName)
        {
            return SessionGuard.EnsureAdmin(session).ImportAdPerson(sid, domainName);
        }

        [NodeName("SyncPeople")]
        [IsDesignScriptCompatible]
        public static void SyncPeople(ServerSession session, IEnumerable<DPerson> personsForSync)
        {
            SessionGuard.EnsureAdmin(session).SyncPeople(personsForSync);
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

