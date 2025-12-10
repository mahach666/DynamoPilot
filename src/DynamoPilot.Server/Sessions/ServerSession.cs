using System;
using Ascon.Pilot.DataClasses;
using Ascon.Pilot.Server.Api;
using Ascon.Pilot.Server.Api.Contracts;
using Autodesk.DesignScript.Runtime;

#nullable enable

namespace DynamoPilot.Server.Sessions
{
    /// <summary>
    /// Дескриптор активной сессии работы с серверным API Pilot.
    /// Оборачивает HttpPilotClient и созданные на его основе API интерфейсы.
    /// </summary>
    [IsVisibleInDynamoLibrary(false)]
    public sealed class ServerSession : IDisposable
    {
        public ServerSession(ConnectionCredentials credentials,
            HttpPilotClient client,
            IAuthenticationApi authenticationApi,
            IServerApi serverApi,
            string databaseName)
        {
            Credentials = credentials ?? throw new ArgumentNullException(nameof(credentials));
            Client = client ?? throw new ArgumentNullException(nameof(client));
            AuthenticationApi = authenticationApi ?? throw new ArgumentNullException(nameof(authenticationApi));
            ServerApi = serverApi ?? throw new ArgumentNullException(nameof(serverApi));
            DatabaseName = databaseName ?? throw new ArgumentNullException(nameof(databaseName));
        }

        public ConnectionCredentials Credentials { get; }

        public HttpPilotClient Client { get; }

        public IAuthenticationApi AuthenticationApi { get; }

        public IServerApi ServerApi { get; }

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

