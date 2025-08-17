using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.App.Utils;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HistoryItem
{
    public static class Get
    {
        /// <summary>
        /// Получает историю изменений объекта по его уникальному идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [IsDesignScriptCompatible]
        public static PHistoryItem GetByGuid(Guid id)
        {
            var loader = new SynkHistoryItemLoader((IObjectsRepository)StaticMetadata.ObjectsRepository.Unwrap());

            var preRes = loader.LoadHistoryItems(new[] { id }, default).FirstOrDefault();
            if (preRes == null) return null;

            return new PHistoryItem(preRes);
        }

        /// <summary>
        /// Получает историю изменений объекта по его уникальному идентификатору в виде строки
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [IsDesignScriptCompatible]
        public static PHistoryItem GetByStrGuid(string id)
        {
            return GetByGuid(new Guid(id));
        }

        /// <summary>
        /// Получает историю изменений объекта по объекту PDataObject
        /// </summary>
        /// <param name="pDataObject"></param>
        /// <returns></returns>
        [IsDesignScriptCompatible]
        public static List<PHistoryItem> GetByObj(PDataObject pDataObject)
        {
            return pDataObject.HistoryItems.Select(i=>GetByGuid(i)).ToList();
        }
    }
}
