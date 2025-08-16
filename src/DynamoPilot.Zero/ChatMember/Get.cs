using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System;
using System.Collections.Generic;

namespace ChatMember
{
    public static class Get
    {
        /// <summary>
        /// Возвращает участников чата по идентификатору чата
        /// </summary>
        /// <param name="chatId">Идентификатор чата</param>
        /// <param name="dateFromUtc">Дата начала периода (UTC)</param>
        /// <returns>Список участников</returns>
        [IsDesignScriptCompatible]
        public static List<PChatMember> GetChatMembersById(Guid chatId, DateTime dateFromUtc)
        {
            var repo = MessagesRepository.Get.GetMessagesRepository();
            return repo.LoadChatMembers(chatId, dateFromUtc);
        }

        /// <summary>
        /// Возвращает участников чата
        /// </summary>
        /// <param name="chat">Чат</param>
        /// <param name="dateFromUtc">Дата начала периода (UTC)</param>
        /// <returns>Список участников</returns>
        [IsDesignScriptCompatible]
        public static List<PChatMember> GetChatMembersByChat(PChat chat, DateTime dateFromUtc)
        {
            return GetChatMembersById(chat.Id, dateFromUtc);
        }

        /// <summary>
        /// Возвращает участников по объекту данных (его Id)
        /// </summary>
        /// <param name="obj">Объект данных</param>
        /// <param name="dateFromUtc">Дата начала периода (UTC)</param>
        /// <returns>Список участников</returns>
        [IsDesignScriptCompatible]
        public static List<PChatMember> GetChatMembersByObj(PDataObject obj, DateTime dateFromUtc)
        {
            return GetChatMembersById(obj.Id, dateFromUtc);
        }
    }
}
