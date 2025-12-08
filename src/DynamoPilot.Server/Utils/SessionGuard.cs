using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using Ascon.Pilot.Server.Api.Contracts;
using DynamoPilot.Server.Sessions;

#nullable enable

namespace DynamoPilot.Server.Utils
{
    internal static class SessionGuard
    {
        internal static ServerSession EnsureSession(ServerSession? session)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session), "Сначала вызовите узел соединения с сервером.");

            return session;
        }

        internal static Guid[] ParseGuids(IEnumerable<string> rawIds)
        {
            if (rawIds == null)
                return Array.Empty<Guid>();

            return rawIds
                .Select(value => Guid.TryParse(value, out var id) ? id : (Guid?)null)
                .Where(id => id.HasValue)
                .Select(id => id!.Value)
                .ToArray();
        }

        internal static SecureString ToSecureString(string value)
        {
            var secure = new SecureString();

            if (!string.IsNullOrEmpty(value))
            {
                foreach (var c in value)
                    secure.AppendChar(c);
            }

            secure.MakeReadOnly();
            return secure;
        }

        internal static IServerAdminApi EnsureAdmin(ServerSession session)
        {
            var ensured = EnsureSession(session);
            if (ensured.AdminApi == null)
                throw new InvalidOperationException("Админский API недоступен в текущей сессии.");
            return ensured.AdminApi;
        }
    }
}

