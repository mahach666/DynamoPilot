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
        public static string UploadLicense(ServerSession session, byte[] buffer, string fileName)
        {
            return SessionGuard.EnsureAdmin(session).UploadLicenseToServer(buffer, fileName);
        }

        [NodeName("ReplaceLicense")]
        [IsDesignScriptCompatible]
        public static void ReplaceLicense(ServerSession session, byte[] buffer, string fileName, Guid licenseToReplace)
        {
            SessionGuard.EnsureAdmin(session).ReplaceLicense(buffer, fileName, licenseToReplace);
        }

        [NodeName("DeleteLicense")]
        [IsDesignScriptCompatible]
        public static void DeleteLicense(ServerSession session, Guid licenseId)
        {
            SessionGuard.EnsureAdmin(session).DeleteLicenseFromServer(licenseId);
        }

        [NodeName("GetLicenseInformation")]
        [IsDesignScriptCompatible]
        public static byte[] GetLicenseInformation(ServerSession session)
        {
            return SessionGuard.EnsureAdmin(session).GetLicenseInformation();
        }

        [NodeName("GetLicensesInformation")]
        [IsDesignScriptCompatible]
        public static IList<byte[]> GetLicensesInformation(ServerSession session)
        {
            return SessionGuard.EnsureAdmin(session).GetLicensesInformation();
        }

        [NodeName("GetLicenseConnections")]
        [IsDesignScriptCompatible]
        public static void GetLicenseConnections(ServerSession session)
        {
            SessionGuard.EnsureAdmin(session).GetLicenseConnections();
        }

        [NodeName("GetLicenseConnectionsById")]
        [IsDesignScriptCompatible]
        public static void GetLicenseConnectionsById(ServerSession session, Guid licenseId)
        {
            SessionGuard.EnsureAdmin(session).GetLicenseConnections(licenseId);
        }
    }
}

