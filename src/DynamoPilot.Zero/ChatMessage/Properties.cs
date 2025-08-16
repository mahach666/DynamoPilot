using Ascon.Pilot.SDK.Data;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatMessage
{
    public static class Properties
    {
        /// <summary>
        /// Возвращает идентификатор сообщения
        /// </summary>
        /// <param name="pChatMessage">Сообщение</param>
        /// <returns>Идентификатор сообщения</returns>
        [IsDesignScriptCompatible]
        public static Guid GetId(PChatMessage pChatMessage) => pChatMessage.Id;

        /// <summary>
        /// Возвращает бинарные данные сообщения
        /// </summary>
        /// <param name="pChatMessage">Сообщение</param>
        /// <returns>Массив байт</returns>
        [IsDesignScriptCompatible]
        public static byte[] GetByteData(PChatMessage pChatMessage) => pChatMessage.Data;

        /// <summary>
        /// Возвращает строковое представление данных сообщения (UTF8)
        /// </summary>
        /// <param name="pChatMessage">Сообщение</param>
        /// <returns>Строка данных</returns>
        [IsDesignScriptCompatible]
        public static string GetStringData(PChatMessage pChatMessage) => Encoding.UTF8.GetString(pChatMessage.Data);

        /// <summary>
        /// Возвращает идентификатор создателя сообщения
        /// </summary>
        /// <param name="pChatMessage">Сообщение</param>
        /// <returns>Идентификатор пользователя</returns>
        [IsDesignScriptCompatible]
        public static int GetCreatorId(PChatMessage pChatMessage) => pChatMessage.CreatorId;

        /// <summary>
        /// Возвращает дату получения сообщения сервером (UTC)
        /// </summary>
        /// <param name="pChatMessage">Сообщение</param>
        /// <returns>Дата/время UTC или null</returns>
        [IsDesignScriptCompatible]
        public static DateTime? GetServerDateUtc(PChatMessage pChatMessage) => pChatMessage.ServerDateUtc;

        /// <summary>
        /// Возвращает дату создания сообщения на клиенте (UTC)
        /// </summary>
        /// <param name="pChatMessage">Сообщение</param>
        /// <returns>Дата/время UTC</returns>
        [IsDesignScriptCompatible]
        public static DateTime GetClientDateUtc(PChatMessage pChatMessage) => pChatMessage.ClientDateUtc;

        /// <summary>
        /// Возвращает идентификатор чата
        /// </summary>
        /// <param name="pChatMessage">Сообщение</param>
        /// <returns>Идентификатор чата</returns>
        [IsDesignScriptCompatible]
        public static Guid GetChatId(PChatMessage pChatMessage) => pChatMessage.ChatId;

        /// <summary>
        /// Возвращает идентификатор связанного сообщения
        /// </summary>
        /// <param name="pChatMessage">Сообщение</param>
        /// <returns>Идентификатор сообщения или null</returns>
        [IsDesignScriptCompatible]
        public static Guid? GetRelatedMessageId(PChatMessage pChatMessage) => pChatMessage.RelatedMessageId;

        /// <summary>
        /// Возвращает тип сообщения
        /// </summary>
        /// <param name="pChatMessage">Сообщение</param>
        /// <returns>Тип сообщения</returns>
        [IsDesignScriptCompatible]
        public static MessageType GetType(PChatMessage pChatMessage) => pChatMessage.Type;

        /// <summary>
        /// Возвращает связанные сообщения
        /// </summary>
        /// <param name="pChatMessage">Сообщение</param>
        /// <returns>Список связанных сообщений</returns>
        [IsDesignScriptCompatible]
        public static List<PChatMessage> GetRelatedMessages(PChatMessage pChatMessage) 
            => pChatMessage.RelatedMessages
            .Select(i => new PChatMessage((IChatMessage)i.Unwrap()))
            .ToList();

        //public static string GetStringData(PChatMessage pChatMessage)
        //{
        //    return pChatMessage.GetData<string>();
        //}
    }
}
