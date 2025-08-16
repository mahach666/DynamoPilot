using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System;
using System.Collections.Generic;

namespace ChatMessage
{
    public static class Get
    {
        public static List<PChatMessage> GetMessagesByChatId(Guid chatId,
            DateTime dateFromUtc,
            DateTime dateToUtc,
            int maxNumber = 999)
        {
            return StaticMetadata.MessagesRepository.LoadMessages( chatId,
                dateFromUtc,
                dateToUtc,
                maxNumber);
        }

        public static List<PChatMessage> GetMessagesByChat(PChat chat,
            DateTime dateFromUtc,
            DateTime dateToUtc,
            int maxNumber = 999)
        {
            return GetMessagesByChatId(chat.Id,
                dateFromUtc,
                dateToUtc,
                maxNumber);
        }

        public static List<PChatMessage> GetMessagesByObj(PDataObject obj,
            DateTime dateFromUtc,
            DateTime dateToUtc,
            int maxNumber = 999)
        {
            return GetMessagesByChatId(obj.Id, dateFromUtc, dateToUtc, maxNumber);
        }
    }
}
