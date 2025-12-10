using System;
using System.Collections.Generic;
using Ascon.Pilot.DataClasses;
using Ascon.Pilot.Server.Api.Contracts;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace ServerAdmin
{
    /// <summary>
    /// Операции с лицензиями на сервере.
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.Licenses")]
    [NodeDescription("Управление лицензиями на сервере")]
    public static class Licenses
    {
        [NodeName("UploadLicense")]
        [IsDesignScriptCompatible]
        public static string UploadLicense(ServerSession session, string base64, string fileName)
        {
            var data = string.IsNullOrEmpty(base64) ? Array.Empty<byte>() : Convert.FromBase64String(base64);
            return SessionGuard.EnsureAdmin(session).UploadLicenseToServer(data, fileName);
        }

        [NodeName("ReplaceLicense")]
        [IsDesignScriptCompatible]
        public static void ReplaceLicense(ServerSession session, string base64, string fileName, string licenseToReplace)
        {
            var data = string.IsNullOrEmpty(base64) ? Array.Empty<byte>() : Convert.FromBase64String(base64);
            SessionGuard.EnsureAdmin(session).ReplaceLicense(data, fileName, Guid.Parse(licenseToReplace));
        }

        [NodeName("DeleteLicense")]
        [IsDesignScriptCompatible]
        public static void DeleteLicense(ServerSession session, string licenseId)
        {
            SessionGuard.EnsureAdmin(session).DeleteLicenseFromServer(Guid.Parse(licenseId));
        }

        [NodeName("GetLicenseInformation")]
        [IsDesignScriptCompatible]
        public static string GetLicenseInformation(ServerSession session)
        {
            var data = SessionGuard.EnsureAdmin(session).GetLicenseInformation();
            return data == null ? string.Empty : Convert.ToBase64String(data);
        }

        [NodeName("GetLicensesInformation")]
        [IsDesignScriptCompatible]
        public static IList<string> GetLicensesInformation(ServerSession session)
        {
            var list = new List<string>();
            foreach (var b in SessionGuard.EnsureAdmin(session).GetLicensesInformation())
            {
                list.Add(b == null ? string.Empty : Convert.ToBase64String(b));
            }
            return list;
        }

        [NodeName("GetLicenseConnections")]
        [IsDesignScriptCompatible]
        public static void GetLicenseConnections(ServerSession session)
        {
            SessionGuard.EnsureAdmin(session).GetLicenseConnections();
        }

        [NodeName("GetLicenseConnectionsById")]
        [IsDesignScriptCompatible]
        public static void GetLicenseConnectionsById(ServerSession session, string licenseId)
        {
            SessionGuard.EnsureAdmin(session).GetLicenseConnections(Guid.Parse(licenseId));
        }
    }
}

