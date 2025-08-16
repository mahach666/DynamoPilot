using Ascon.Pilot.SDK.Data;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System;

namespace Chat
{
    public static class Properties
    {
        /// <summary>
        /// Возвращает идентификатор чата
        /// </summary>
        /// <param name="pChat">Чат</param>
        /// <returns>Идентификатор чата</returns>
        [IsDesignScriptCompatible]
        public static Guid Id(PChat pChat) => pChat.Id;

        /// <summary>
        /// Возвращает имя чата
        /// </summary>
        /// <param name="pChat">Чат</param>
        /// <returns>Имя чата</returns>
        [IsDesignScriptCompatible]
        public static string Name(PChat pChat) => pChat.Name;

        /// <summary>
        /// Возвращает описание чата
        /// </summary>
        /// <param name="pChat">Чат</param>
        /// <returns>Описание</returns>
        [IsDesignScriptCompatible]
        public static string Description(PChat pChat) => pChat.Description;

        /// <summary>
        /// Возвращает идентификатор создателя чата
        /// </summary>
        /// <param name="pChat">Чат</param>
        /// <returns>Идентификатор пользователя</returns>
        [IsDesignScriptCompatible]
        public static int CreatorId(PChat pChat) => pChat.CreatorId;

        /// <summary>
        /// Возвращает тип чата
        /// </summary>
        /// <param name="pChat">Чат</param>
        /// <returns>Тип чата</returns>
        [IsDesignScriptCompatible]
        public static ChatKind Type(PChat pChat) => pChat.Type;

        /// <summary>
        /// Возвращает идентификатор последнего сообщения
        /// </summary>
        /// <param name="pChat">Чат</param>
        /// <returns>Идентификатор сообщения или null</returns>
        [IsDesignScriptCompatible]
        public static Guid? LastMessageId(PChat pChat) => pChat.LastMessageId;

        /// <summary>
        /// Возвращает дату создания чата в UTC
        /// </summary>
        /// <param name="pChat">Чат</param>
        /// <returns>Дата создания в UTC</returns>
        [IsDesignScriptCompatible]
        public static DateTime CreationDateUtc(PChat pChat) => pChat.CreationDateUtc;
    }
}
