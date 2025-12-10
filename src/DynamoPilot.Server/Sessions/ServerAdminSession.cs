using System;
using Ascon.Pilot.DataClasses;
using Ascon.Pilot.Server.Api;
using Ascon.Pilot.Server.Api.Contracts;
using Autodesk.DesignScript.Runtime;

namespace DynamoPilot.Server.Sessions
{
    /// <summary>
    /// Дескриптор сессии для административного API (IServerAdminApi).
    /// </summary>
    [IsVisibleInDynamoLibrary(false)]
    public sealed class ServerAdminSession : IDisposable
    {
        public ServerAdminSession(
            ConnectionCredentials credentials,
            HttpPilotClient client,
            IAuthenticationApi authenticationApi,
            IServerAdminApi serverAdminApi,
            string databaseName)
        {
            Credentials = credentials ?? throw new ArgumentNullException(nameof(credentials));
            Client = client ?? throw new ArgumentNullException(nameof(client));
            AuthenticationApi = authenticationApi ?? throw new ArgumentNullException(nameof(authenticationApi));
            ServerAdminApi = serverAdminApi ?? throw new ArgumentNullException(nameof(serverAdminApi));
            DatabaseName = databaseName;
        }

        public ConnectionCredentials Credentials { get; }

        public HttpPilotClient Client { get; }

        public IAuthenticationApi AuthenticationApi { get; }

        public IServerAdminApi ServerAdminApi { get; }

        /// <summary>
        /// Имя базы данных, к которой подключена сессия.
        /// </summary>
        public string DatabaseName { get; }

        public DDatabaseInfo? DatabaseInfo { get; internal set; }

        public DMetadata? Metadata { get; internal set; }

        public void Dispose()
        {
            Client.Dispose();
        }
    }
}

