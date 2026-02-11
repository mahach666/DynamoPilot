using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;
using System;
using System.Collections.Generic;

namespace Admin.Licenses
{
    /// <summary>
    /// Чтение информации о лицензиях.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.Licenses")]
    [NodeDescription("Чтение лицензий и подключений через ServerAdminApi")]
    public static class Get
    {
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

    /// <summary>
    /// Изменение лицензий.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.Licenses")]
    [NodeDescription("Загрузка, замена и удаление лицензий через ServerAdminApi")]
    public static class Edit
    {
        private const string DefaultLicenseFileName = "license.lic";

        [NodeName("UploadLicenseToServer")]
        [IsDesignScriptCompatible]
        public static string UploadLicenseToServer(ServerAdminSession session, byte[] buffer)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            return api.UploadLicenseToServer(buffer ?? Array.Empty<byte>(), DefaultLicenseFileName);
        }

        [NodeName("ReplaceLicense")]
        [IsDesignScriptCompatible]
        public static void ReplaceLicense(ServerAdminSession session, byte[] buffer, Guid licenseToReplace)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.ReplaceLicense(buffer ?? Array.Empty<byte>(), DefaultLicenseFileName, licenseToReplace);
        }

        [NodeName("DeleteLicenseFromServer")]
        [IsDesignScriptCompatible]
        public static void DeleteLicenseFromServer(ServerAdminSession session, Guid licenseId)
        {
            var api = SessionGuard.EnsureAdminSession(session).ServerAdminApi;
            api.DeleteLicenseFromServer(licenseId);
        }
    }
}

