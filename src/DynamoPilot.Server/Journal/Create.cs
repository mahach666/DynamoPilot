using System;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace SJournal
{
    /// <summary>
    /// Узлы для формирования запросов к журналам действий.
    /// </summary>
    [NodeCategory("Pilot.Server.Journal")]
    [NodeDescription("Создание запросов для журналов действий пользователей и администраторов")]
    public static class Create
    {
        /// <summary>
        /// Создает запрос пользовательского журнала.
        /// </summary>
        [NodeName("CreateJournalRequest")]
        [IsDesignScriptCompatible]
        public static JournalRequest CreateJournalRequest(
            int count = 100,
            int? personId = null,
            long? fromId = null,
            EventKind[] eventKinds = null,
            DateTime? startDate = null,
            DateTime? endDate = null,
            int[] objectTypesIds = null)
        {
            var safeCount = count <= 0 ? 100 : count;
            ulong? safeFromId = fromId is { } value && value >= 0 ? (ulong?)value : null;

            return new JournalRequest
            {
                Count = safeCount,
                PersonId = personId,
                FromId = safeFromId,
                EventKinds = eventKinds,
                StartDate = startDate,
                EndDate = endDate,
                ObjectTypesIds = objectTypesIds
            };
        }

        /// <summary>
        /// Создает запрос административного журнала.
        /// </summary>
        [NodeName("CreateAdminJournalRequest")]
        [IsDesignScriptCompatible]
        public static AdminJournalRequest CreateAdminJournalRequest(
            int count = 100,
            string userName = null,
            string ip = null,
            long? fromId = null,
            DateTime? startDate = null,
            DateTime? endDate = null,
            AdminEventKind[] eventKinds = null)
        {
            var safeCount = count <= 0 ? 100 : count;
            ulong? safeFromId = fromId is { } value && value >= 0 ? (ulong?)value : null;

            return new AdminJournalRequest
            {
                Count = safeCount,
                UserName = userName,
                Ip = ip,
                FromId = safeFromId,
                StartDate = startDate,
                EndDate = endDate,
                EventKinds = eventKinds
            };
        }
    }
}

