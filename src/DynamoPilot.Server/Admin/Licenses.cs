using System;
using System.Collections.Generic;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace ServerAdminLicenses
{
    /// <summary>
    /// Управление лицензиями сервера.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.Licenses")]
    [NodeDescription("Работа с лицензиями через ServerAdminApi")]
    public static class Licenses
    {
        [NodeName("UploadLicenseToServer")]
        [IsDesignScriptCompatible]
        public static string UploadLicenseToServer(ServerAdminSession session, byte[] buffer)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.UploadLicenseToServer(buffer ?? Array.Empty<byte>());
        }

        [NodeName("ReplaceLicense")]
        [IsDesignScriptCompatible]
        public static void ReplaceLicense(ServerAdminSession session, byte[] buffer, Guid licenseToReplace)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.ReplaceLicense(buffer ?? Array.Empty<byte>(), licenseToReplace);
        }

        [NodeName("DeleteLicenseFromServer")]
        [IsDesignScriptCompatible]
        public static void DeleteLicenseFromServer(ServerAdminSession session, Guid licenseId)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.DeleteLicenseFromServer(licenseId);
        }

        [NodeName("GetLicenseInformation")]
        [IsDesignScriptCompatible]
        public static byte[] GetLicenseInformation(ServerAdminSession session)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.GetLicenseInformation() ?? Array.Empty<byte>();
        }

        [NodeName("GetLicensesInformation")]
        [IsDesignScriptCompatible]
        public static IList<byte[]> GetLicensesInformation(ServerAdminSession session)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.GetLicensesInformation() ?? new List<byte[]>();
        }

        [NodeName("GetLicenseConnections")]
        [IsDesignScriptCompatible]
        public static void GetLicenseConnections(ServerAdminSession session)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.GetLicenseConnections();
        }

        [NodeName("GetLicenseConnectionsById")]
        [IsDesignScriptCompatible]
        public static void GetLicenseConnections(ServerAdminSession session, Guid licenseId)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.GetLicenseConnections(licenseId);
        }
    }
}

