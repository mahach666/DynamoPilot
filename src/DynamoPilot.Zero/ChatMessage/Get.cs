using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System;
using System.Collections.Generic;

namespace ChatMessage
{
    public static class Get
    {
        /// <summary>
        /// Возвращает сообщения по идентификатору чата и интервалу дат
        /// </summary>
        /// <param name="chatId">Идентификатор чата</param>
        /// <param name="dateFromUtc">Начало периода (UTC)</param>
        /// <param name="dateToUtc">Конец периода (UTC)</param>
        /// <param name="maxNumber">Максимальное число сообщений</param>
        /// <returns>Список сообщений</returns>
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

        /// <summary>
        /// Возвращает сообщения по чату и интервалу дат
        /// </summary>
        /// <param name="chat">Чат</param>
        /// <param name="dateFromUtc">Начало периода (UTC)</param>
        /// <param name="dateToUtc">Конец периода (UTC)</param>
        /// <param name="maxNumber">Максимальное число сообщений</param>
        /// <returns>Список сообщений</returns>
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

        /// <summary>
        /// Возвращает сообщения по объекту (его Id) и интервалу дат
        /// </summary>
        /// <param name="obj">Объект данных</param>
        /// <param name="dateFromUtc">Начало периода (UTC)</param>
        /// <param name="dateToUtc">Конец периода (UTC)</param>
        /// <param name="maxNumber">Максимальное число сообщений</param>
        /// <returns>Список сообщений</returns>
        public static List<PChatMessage> GetMessagesByObj(PDataObject obj,
            DateTime dateFromUtc,
            DateTime dateToUtc,
            int maxNumber = 999)
        {
            return GetMessagesByChatId(obj.Id, dateFromUtc, dateToUtc, maxNumber);
        }
    }
}
