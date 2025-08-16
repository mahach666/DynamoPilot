using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System;
using System.Collections.Generic;

namespace ChatMember
{
    public static class Get
    {
        [IsDesignScriptCompatible]
        public static List<PChatMember> GetChatMembersById(Guid chatId, DateTime dateFromUtc)
        {
            var repo = MessagesRepository.Get.GetMessagesRepository();
            return repo.LoadChatMembers(chatId, dateFromUtc);
        }

        [IsDesignScriptCompatible]
        public static List<PChatMember> GetChatMembersByChat(PChat chat, DateTime dateFromUtc)
        {
            return GetChatMembersById(chat.Id, dateFromUtc);
        }

        [IsDesignScriptCompatible]
        public static List<PChatMember> GetChatMembersByObj(PDataObject obj, DateTime dateFromUtc)
        {
            return GetChatMembersById(obj.Id, dateFromUtc);
        }
    }
}
