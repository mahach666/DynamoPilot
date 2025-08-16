using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System;

namespace Chat
{
    public static class Get
    {
        /// <summary>
        /// Загружает чат по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор чата</param>
        /// <returns>Чат</returns>
        [IsDesignScriptCompatible]
        public static PChat GetChatById(Guid id)
        {
            var repo = MessagesRepository.Get.GetMessagesRepository();
            return repo.LoadChat(id);
        }

        /// <summary>
        /// Загружает чат по строковому идентификатору
        /// </summary>
        /// <param name="id">Строковое представление GUID</param>
        /// <returns>Чат</returns>
        [IsDesignScriptCompatible]
        public static PChat GetChatByStrId(string id)
        {
            return GetChatById(new Guid(id));
        }

        /// <summary>
        /// Загружает чат по объекту данных (его Id)
        /// </summary>
        /// <param name="obj">Объект данных</param>
        /// <returns>Чат</returns>
        [IsDesignScriptCompatible]
        public static PChat GetChatByObj(PDataObject obj)
        {
            return GetChatById(obj.Id);
        }
    }
}
