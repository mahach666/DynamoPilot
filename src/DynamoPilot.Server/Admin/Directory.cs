using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Admin.Directory
{
    /// <summary>
    /// Чтение данных из AD/LDAP.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.Directory")]
    [NodeDescription("Чтение AD/LDAP через ServerAdminApi")]
    public static class Get
    {
        [NodeName("GetDomains")]
        [IsDesignScriptCompatible]
        public static IEnumerable<string> GetDomains(ServerAdminSession session)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.GetDomains() ?? new List<string>();
        }

        [NodeName("GetAdUsers")]
        [IsDesignScriptCompatible]
        public static IEnumerable<AdUser> GetAdUsers(ServerAdminSession session, string domainName, string searchRequest)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.GetAdUsers(domainName, searchRequest) ?? new List<AdUser>();
        }

        [NodeName("GetAdUser")]
        [IsDesignScriptCompatible]
        public static AdUser GetAdUser(ServerAdminSession session, string sid, string domainName)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.GetAdUser(sid, domainName);
        }

        [NodeName("GetLdapUsers")]
        [IsDesignScriptCompatible]
        public static IEnumerable<LdapUser> GetLdapUsers(ServerAdminSession session, string searchRequest)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.GetLdapUsersAsync(searchRequest).GetAwaiter().GetResult() ?? new List<LdapUser>();
        }

        [NodeName("GetLdapUser")]
        [IsDesignScriptCompatible]
        public static LdapUser GetLdapUser(ServerAdminSession session, string userId)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.GetLdapUserAsync(userId).GetAwaiter().GetResult();
        }

        [NodeName("GetLdapServer")]
        [IsDesignScriptCompatible]
        public static LdapServer GetLdapServer(ServerAdminSession session)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.GetLdapServer();
        }
    }

    /// <summary>
    /// Импорт и настройки AD/LDAP.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.Directory")]
    [NodeDescription("Импорт и синхронизация пользователей AD/LDAP через ServerAdminApi")]
    public static class DirectoryEdit
    {
        [NodeName("SetLdapServer")]
        [IsDesignScriptCompatible]
        public static void SetLdapServer(
            ServerAdminSession session,
            string url,
            bool enableSsl,
            string sslThumbprint,
            bool useVlv,
            string username,
            string password,
            LdapParameters ldapParameters)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.SetLdapServer(url, enableSsl, sslThumbprint, useVlv, username, password, ldapParameters);
        }

        [NodeName("ImportAdPerson")]
        [IsDesignScriptCompatible]
        public static DPerson ImportAdPerson(ServerAdminSession session, string sid, string domainName)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.ImportAdPerson(sid, domainName);
        }

        [NodeName("ImportLdapPerson")]
        [IsDesignScriptCompatible]
        public static DPerson ImportLdapPerson(ServerAdminSession session, string ldapLogin)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.ImportLdapPersonAsync(ldapLogin).GetAwaiter().GetResult();
        }

        [NodeName("SyncPeople")]
        [IsDesignScriptCompatible]
        public static void SyncPeople(ServerAdminSession session, IEnumerable<DPerson> personsForSync)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.SyncPeople(personsForSync ?? Enumerable.Empty<DPerson>());
        }
    }
}

