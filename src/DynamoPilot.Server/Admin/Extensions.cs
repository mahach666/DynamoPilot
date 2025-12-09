using System.Collections.Generic;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace ServerAdmin
{
    /// <summary>
    /// Получение списка серверных расширений (через reflection, т.к. тип недоступен в текущих сборках).
    /// </summary>
    [NodeCategory("Pilot.Server.Admin.Extensions")]
    [NodeDescription("Список зарегистрированных расширений сервера")]
    public static class Extensions
    {
        [NodeName("ListExtensions")]
        [IsDesignScriptCompatible]
        public static IEnumerable<object> ListExtensions(ServerSession session)
        {
            var admin = SessionGuard.EnsureAdmin(session);
            var method = admin.GetType().GetMethod("ListExtensions");
            var result = method?.Invoke(admin, null);
            return result as IEnumerable<object> ?? new List<object>();
        }
    }
}

