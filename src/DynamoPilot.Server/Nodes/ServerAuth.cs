using Ascon.Pilot.Server.Api;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;
using System;
using System.Text;

namespace ServerAuth
{
    /// <summary>
    /// Узлы для подключения и управления лицензией серверного API.
    /// </summary>
    [NodeCategory("Pilot.Server.Auth")]
    [NodeDescription("Подключение к серверному API Pilot и управление лицензиями")]
    public static class ServerAuth
    {
        /// <summary>
        /// Создает подключение к серверу Pilot, авторизуется и открывает базу.
        /// </summary>
        /// <param name="serverUrl">Адрес сервера, например http://host:5545/pilot-ice_ru</param>
        /// <param name="databaseName">Имя базы. Если пусто, берется из URL.</param>
        /// <param name="login">Логин пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <param name="useWindowsAuth">Использовать Windows-аутентификацию</param>
        /// <param name="licenseType">Код типа лицензии (по умолчанию PILOT_ICE = 100)</param>
        /// <param name="checkClientVersion">Проверять совместимость версий клиента и сервера</param>
        [NodeName("Connect")]
        [IsDesignScriptCompatible]
        public static ServerSession Connect(
            string serverUrl,
            string databaseName,
            string login,
            string password,
            bool useWindowsAuth = false,
            int licenseType = 100,
            bool checkClientVersion = false)
        {
            if (string.IsNullOrWhiteSpace(serverUrl))
                throw new ArgumentException("Адрес сервера не указан", nameof(serverUrl));
            if (string.IsNullOrWhiteSpace(login))
                throw new ArgumentException("Логин не указан", nameof(login));

            var credentials = ConnectionCredentials.GetConnectionCredentials(
                serverUrl,
                login,
                SessionGuard.ToSecureString(password ?? string.Empty));

            var client = new HttpPilotClient(credentials.GetConnectionString(), credentials.GetConnectionProxy());
            client.Connect(checkClientVersion);

            var authApi = client.GetAuthenticationApi();
            var dbName = string.IsNullOrWhiteSpace(databaseName) ? credentials.DatabaseName : databaseName;

            authApi.Login(dbName, credentials.Username, credentials.ProtectedPassword, useWindowsAuth, licenseType);

            var serverApi = client.GetServerApi(null);
            var session = new ServerSession(credentials, client, authApi, serverApi)
            {
                DatabaseInfo = serverApi.OpenDatabase()
            };

            session.Metadata = serverApi.GetMetadata(session.DatabaseInfo?.MetadataVersion ?? 0);
            return session;
        }

        /// <summary>
        /// Завершает сессию и освобождает соединение.
        /// </summary>
        [NodeName("Disconnect")]
        [IsDesignScriptCompatible]
        public static bool Disconnect(ServerSession session)
        {
            SessionGuard.EnsureSession(session).Dispose();
            return true;
        }

        /// <summary>
        /// Возвращает XML с данными лицензии.
        /// </summary>
        [NodeName("GetLicenseInformation")]
        [IsDesignScriptCompatible]
        public static string GetLicenseInformation(ServerSession session)
        {
            var data = SessionGuard.EnsureSession(session).AuthenticationApi.GetLicenseInformation();
            return data == null ? string.Empty : Encoding.UTF8.GetString(data);
        }

        /// <summary>
        /// Захватывает лицензию указанного типа.
        /// </summary>
        [NodeName("ConsumeLicense")]
        [IsDesignScriptCompatible]
        public static void ConsumeLicense(ServerSession session, int licenseType)
        {
            SessionGuard.EnsureSession(session).AuthenticationApi.ConsumeLicense(licenseType);
        }

        /// <summary>
        /// Освобождает лицензию указанного типа.
        /// </summary>
        [NodeName("ReleaseLicense")]
        [IsDesignScriptCompatible]
        public static void ReleaseLicense(ServerSession session, int licenseType)
        {
            SessionGuard.EnsureSession(session).AuthenticationApi.ReleaseLicense(licenseType);
        }
    }
}

