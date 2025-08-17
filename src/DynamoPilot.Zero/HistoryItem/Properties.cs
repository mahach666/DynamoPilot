using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System;

namespace HistoryItem
{
    public static class Properties
    {
        /// <summary>
        /// Получает уникальный идентификатор элемента истории изменений
        /// </summary>
        /// <param name="pHistoryItem"></param>
        /// <returns></returns>
        [IsDesignScriptCompatible]
        public static Guid GetId(PHistoryItem pHistoryItem) => pHistoryItem.Id;

        /// <summary>
        /// Получает уникальный идентификатор объекта, к которому относится элемент истории изменений
        /// </summary>
        /// <param name="pHistoryItem"></param>
        /// <returns></returns>
        [IsDesignScriptCompatible]
        public static Guid ObjectId(PHistoryItem pHistoryItem) => pHistoryItem.ObjectId;

        /// <summary>
        /// Получает причину изменения, указанную в элементе истории изменений
        /// </summary>
        /// <param name="pHistoryItem"></param>
        /// <returns></returns>
        [IsDesignScriptCompatible]
        public static string Reason(PHistoryItem pHistoryItem) => pHistoryItem.Reason;

        /// <summary>
        /// Получает дату и время создания элемента истории изменений
        /// </summary>
        /// <param name="pHistoryItem"></param>
        /// <returns></returns>
        [IsDesignScriptCompatible]
        public static DateTime Created(PHistoryItem pHistoryItem) => pHistoryItem.Created;

        /// <summary>
        /// Получает идентификатор создателя элемента истории изменений
        /// </summary>
        /// <param name="pHistoryItem"></param>
        /// <returns></returns>
        [IsDesignScriptCompatible]
        public static int CreatorId(PHistoryItem pHistoryItem) => pHistoryItem.CreatorId;

        /// <summary>
        /// Получает объект данных, к которому относится элемент истории изменений
        /// </summary>
        /// <param name="pHistoryItem"></param>
        /// <returns></returns>
        [IsDesignScriptCompatible]
        public static PDataObject Object(PHistoryItem pHistoryItem) => pHistoryItem.Object;
    }
}
