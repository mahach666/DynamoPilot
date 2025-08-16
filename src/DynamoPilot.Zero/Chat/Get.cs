using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System;

namespace Chat
{
    public static class Get
    {
        [IsDesignScriptCompatible]
        public static PChat GetChatById(Guid id)
        {
            var repo = MessagesRepository.Get.GetMessagesRepository();
            return repo.LoadChat(id);
        }

        [IsDesignScriptCompatible]
        public static PChat GetChatByStrId(string id)
        {
            return GetChatById(new Guid(id));
        }

        [IsDesignScriptCompatible]
        public static PChat GetChatByObj(PDataObject obj)
        {
            return GetChatById(obj.Id);
        }
    }
}
