using System;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Server.Sessions;
using DynamoPilot.Server.Utils;

namespace ServerCommand
{
    /// <summary>
    /// Узлы для выполнения команд и работы с пользовательскими уведомлениями.
    /// </summary>
    [NodeCategory("Pilot.Server.Command")]
    [NodeDescription("InvokeCommand и кастомные уведомления через ServerApi")]
    public static class CustomNotifications
    {
        [NodeName("InvokeCommand")]
        [IsDesignScriptCompatible]
        public static void InvokeCommand(ServerSession session, string commandName, string requestId, byte[] data)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            srv.InvokeCommand(commandName, Guid.Parse(requestId), data ?? Array.Empty<byte>());
        }

        [NodeName("SubscribeCustomNotification")]
        [IsDesignScriptCompatible]
        public static void SubscribeCustomNotification(ServerSession session, string name)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            srv.SubscribeCustomNotification(name);
        }

        [NodeName("UnsubscribeCustomNotification")]
        [IsDesignScriptCompatible]
        public static void UnsubscribeCustomNotification(ServerSession session, string name)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            srv.UnsubscribeCustomNotification(name);
        }

        [NodeName("SendCustomNotification")]
        [IsDesignScriptCompatible]
        public static void SendCustomNotification(ServerSession session, string name, byte[] data)
        {
            var srv = SessionGuard.EnsureSession(session).ServerApi;
            srv.SendCustomNotification(name, data ?? Array.Empty<byte>());
        }
    }
}

