using Ascon.Pilot.Server.Api;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Utils;

namespace Utils
{
    /// <summary>
    /// Узлы для подготовки зашифрованного пароля под Admin API.
    /// </summary>
    [NodeCategory("Pilot.Server.People")]
    [NodeDescription("Шифрование пароля для CreatePerson/ChangePeople")]
    public static class Password
    {
        /// <summary>
        /// Возвращает зашифрованную строку, подходящую для ChangePeople/CreatePerson.
        /// </summary>
        [NodeName("ProtectPassword")]
        [IsDesignScriptCompatible]
        public static string ProtectPassword(string plainPassword)
        {
            var secure = SessionGuard.ToSecureString(plainPassword ?? string.Empty);
            // username/url не влияют на сам способ шифрования, используем заглушки
            var creds = ConnectionCredentials.GetConnectionCredentials("http://localhost", "user", secure);
            return creds.ProtectedPassword;
        }
    }
}

