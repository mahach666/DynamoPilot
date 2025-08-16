using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System;

namespace Search.Filters
{
    /// <summary>
    /// Ноды для фильтрации объектов в построителях запросов
    /// </summary>
    public static class ObjectFilters
    {
        /// <summary>
        /// Фильтрует объекты по идентификатору
        /// </summary>
        /// <param name="builder">Построитель запросов</param>
        /// <param name="id">Идентификатор объекта</param>
        /// <param name="reverse">Обратная фильтрация (исключение)</param>
        /// <returns>Обновленный построитель запросов</returns>
        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterById(PQueryBuilder builder,
            Guid id,
            bool reverse = false)
        {
            if (reverse)
                builder.MustNot(ObjectFields.Id.Be(id));
            else
                builder.Must(ObjectFields.Id.Be(id));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByContextId(
            PQueryBuilder builder,
            Guid id,
            bool reverse = false)
        {
            if (reverse)
                builder.MustNot(ObjectFields.Context.Be(id));
            else
                builder.Must(ObjectFields.Context.Be(id));
            return builder;
        }

        /// <summary>
        /// Фильтрует по идентификатору контекста (строковый GUID)
        /// </summary>
        /// <param name="builder">Построитель запросов</param>
        /// <param name="id">Строковый GUID контекста</param>
        /// <param name="reverse">Если true — инвертировать условие</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByContextStrId(
            PQueryBuilder builder,
            string id,
            bool reverse = false)
        {
            return FilterByContextId(builder, new Guid(id), reverse);
        }

        /// <summary>
        /// Фильтрует по множеству идентификаторов объектов
        /// </summary>
        /// <param name="builder">Построитель запросов</param>
        /// <param name="ids">Массив GUID</param>
        /// <param name="reverse">Если true — инвертировать условие</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByIds(PQueryBuilder builder,
            Guid[] ids,
            bool reverse = false)
        {
            if (reverse)
                builder.MustNot(ObjectFields.Id.BeAnyOf(ids));
            else
                builder.Must(ObjectFields.Id.BeAnyOf(ids));
            return builder;
        }

        /// <summary>
        /// Фильтрует по идентификатору родителя
        /// </summary>
        /// <param name="builder">Построитель запросов</param>
        /// <param name="parentId">GUID родительского объекта</param>
        /// <param name="reverse">Если true — инвертировать условие</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByParentId(PQueryBuilder builder,
            Guid parentId,
            bool reverse = false)
        {
            if (reverse)
                builder.MustNot(ObjectFields.ParentId.Be(parentId));
            else
                builder.Must(ObjectFields.ParentId.Be(parentId));
            return builder;
        }

        /// <summary>
        /// Фильтрует по множеству идентификаторов родителей
        /// </summary>
        /// <param name="builder">Построитель запросов</param>
        /// <param name="parentIds">Массив GUID родителей</param>
        /// <param name="reverse">Если true — инвертировать условие</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByParentIds(PQueryBuilder builder,
            Guid[] parentIds,
            bool reverse = false)
        {
            if (reverse)
                builder.MustNot(ObjectFields.ParentId.BeAnyOf(parentIds));
            else
                builder.Must(ObjectFields.ParentId.BeAnyOf(parentIds));
            return builder;
        }

        /// <summary>
        /// Фильтрует по идентификатору типа
        /// </summary>
        /// <param name="builder">Построитель запросов</param>
        /// <param name="typeId">Идентификатор типа</param>
        /// <param name="reverse">Если true — инвертировать условие</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByTypeId(PQueryBuilder builder,
            int typeId,
            bool reverse = false)
        {
            if (reverse)
                builder.MustNot(ObjectFields.TypeId.Be(typeId));
            else
                builder.Must(ObjectFields.TypeId.Be(typeId));
            return builder;
        }

        /// <summary>
        /// Фильтрует по множеству идентификаторов типов
        /// </summary>
        /// <param name="builder">Построитель запросов</param>
        /// <param name="typeIds">Массив идентификаторов типов</param>
        /// <param name="reverse">Если true — инвертировать условие</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByTypeIds(PQueryBuilder builder,
            int[] typeIds,
            bool reverse = false)
        {
            if (reverse)
                builder.MustNot(ObjectFields.TypeId.BeAnyOf(typeIds));
            else
                builder.Must(ObjectFields.TypeId.BeAnyOf(typeIds));
            return builder;
        }

        /// <summary>
        /// Фильтрует по состоянию объекта
        /// </summary>
        /// <param name="builder">Построитель запросов</param>
        /// <param name="objectState">Состояние объекта</param>
        /// <param name="reverse">Если true — инвертировать условие</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByObjectState(PQueryBuilder builder,
            ObjectState objectState,
            bool reverse = false)
        {
            if (reverse)
                builder.MustNot(ObjectFields.ObjectState.Be(objectState));
            else
                builder.Must(ObjectFields.ObjectState.Be(objectState));
            return builder;
        }

        /// <summary>
        /// Фильтрует по идентификатору создателя
        /// </summary>
        /// <param name="builder">Построитель запросов</param>
        /// <param name="creatorId">Идентификатор пользователя</param>
        /// <param name="reverse">Если true — инвертировать условие</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByCreatorId(PQueryBuilder builder,
            int creatorId,
            bool reverse = false)
        {
            if (reverse)
                builder.MustNot(ObjectFields.CreatorId.Be(creatorId));
            else
                builder.Must(ObjectFields.CreatorId.Be(creatorId));
            return builder;
        }

        /// <summary>
        /// Фильтрует по множеству идентификаторов создателей
        /// </summary>
        /// <param name="builder">Построитель запросов</param>
        /// <param name="creatorIds">Массив идентификаторов пользователей</param>
        /// <param name="reverse">Если true — инвертировать условие</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByCreatorIds(PQueryBuilder builder,
            int[] creatorIds,
            bool reverse = false)
        {
            if (reverse)
                builder.MustNot(ObjectFields.CreatorId.BeAnyOf(creatorIds));
            else
                builder.Must(ObjectFields.CreatorId.BeAnyOf(creatorIds));
            return builder;
        }

        /// <summary>
        /// Фильтрует по диапазону дат создания
        /// </summary>
        /// <param name="builder">Построитель запросов</param>
        /// <param name="fromDate">Начало периода (локальное время)</param>
        /// <param name="toDate">Конец периода (локальное время)</param>
        /// <param name="reverse">Если true — инвертировать условие</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByCreatedDateRange(PQueryBuilder builder,
            DateTime fromDate,
            DateTime toDate,
            bool reverse = false)
        {
            if (reverse)
                builder.MustNot(ObjectFields.CreatedDate.BeInRange(fromDate.ToUniversalTime(), toDate.ToUniversalTime()));
            else
                builder.Must(ObjectFields.CreatedDate.BeInRange(fromDate.ToUniversalTime(), toDate.ToUniversalTime()));
            return builder;
        }

        /// <summary>
        /// Фильтрует по признаку секретности
        /// </summary>
        /// <param name="builder">Построитель запросов</param>
        /// <param name="isSecret">True для секретных</param>
        /// <param name="reverse">Если true — инвертировать условие</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByIsSecret(PQueryBuilder builder,
            bool isSecret,
            bool reverse = false)
        {
            if (reverse)
                builder.MustNot(ObjectFields.IsSecret.Be(isSecret));
            else
                builder.Must(ObjectFields.IsSecret.Be(isSecret));
            return builder;
        }

        /// <summary>
        /// Фильтрует по текстовому содержимому
        /// </summary>
        /// <param name="builder">Построитель запросов</param>
        /// <param name="searchText">Текст поиска</param>
        /// <param name="reverse">Если true — инвертировать условие</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByAllText(PQueryBuilder builder,
            string searchText,
            bool reverse = false)
        {
            if (reverse)
                builder.MustNot(ObjectFields.AllText.Be(searchText));
            else
                builder.Must(ObjectFields.AllText.Be(searchText));
            return builder;
        }

        /// <summary>
        /// Фильтрует по наличию всех указанных слов в тексте
        /// </summary>
        /// <param name="builder">Построитель запросов</param>
        /// <param name="searchWords">Слова для поиска</param>
        /// <param name="reverse">Если true — инвертировать условие</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByAllTextContainsAll(PQueryBuilder builder,
            string[] searchWords,
            bool reverse = false)
        {
            if (reverse)
                builder.MustNot(ObjectFields.AllText.ContainsAll(searchWords));
            else
                builder.Must(ObjectFields.AllText.ContainsAll(searchWords));
            return builder;
        }

        /// <summary>
        /// Фильтрует по диапазону дат создания файловых версий (snapshots)
        /// </summary>
        /// <param name="builder">Построитель запросов</param>
        /// <param name="fromDate">Начало периода (локальное время)</param>
        /// <param name="toDate">Конец периода (локальное время)</param>
        /// <param name="reverse">Если true — инвертировать условие</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterBySnapshotsCreatedRange(PQueryBuilder builder,
            DateTime fromDate,
            DateTime toDate,
            bool reverse = false)
        {
            if (reverse)
                builder.MustNot(ObjectFields.SnapshotsCreated.BeInRange(fromDate.ToUniversalTime(), toDate.ToUniversalTime()));
            else
                builder.Must(ObjectFields.SnapshotsCreated.BeInRange(fromDate.ToUniversalTime(), toDate.ToUniversalTime()));
            return builder;
        }

        /// <summary>
        /// Фильтрует по причине создания версии
        /// </summary>
        /// <param name="builder">Построитель запросов</param>
        /// <param name="reason">Причина</param>
        /// <param name="reverse">Если true — инвертировать условие</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByAllSnapshotsReason(PQueryBuilder builder,
            string reason,
            bool reverse = false)
        {
            if (reverse)
                builder.MustNot(ObjectFields.AllSnapshotsReason.Be(reason));
            else
                builder.Must(ObjectFields.AllSnapshotsReason.Be(reason));
            return builder;
        }

        /// <summary>
        /// Фильтрует документы, ожидающие подписи указанной должностью
        /// </summary>
        /// <param name="builder">Построитель запросов</param>
        /// <param name="positionId">Идентификатор должности</param>
        /// <param name="reverse">Если true — инвертировать условие</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterBySignatureAwaitingBy(PQueryBuilder builder,
            int positionId,
            bool reverse = false)
        {
            if (reverse)
                builder.MustNot(ObjectFields.SignatureAwaitingBy.Be(positionId));
            else
                builder.Must(ObjectFields.SignatureAwaitingBy.Be(positionId));
            return builder;
        }

        /// <summary>
        /// Фильтрует документы, ожидающие подписи одной из указанных должностей
        /// </summary>
        /// <param name="builder">Построитель запросов</param>
        /// <param name="positionIds">Массив идентификаторов должностей</param>
        /// <param name="reverse">Если true — инвертировать условие</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterBySignatureAwaitingByMultiple(PQueryBuilder builder,
            int[] positionIds,
            bool reverse = false)
        {
            if (reverse)
                builder.MustNot(ObjectFields.SignatureAwaitingBy.BeAnyOf(positionIds));
            else
                builder.Must(ObjectFields.SignatureAwaitingBy.BeAnyOf(positionIds));
            return builder;
        }

        /// <summary>
        /// Фильтрует документы, подписанные указанной должностью
        /// </summary>
        /// <param name="builder">Построитель запросов</param>
        /// <param name="positionId">Идентификатор должности</param>
        /// <param name="reverse">Если true — инвертировать условие</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterBySignedBy(PQueryBuilder builder,
            int positionId,
            bool reverse = false)
        {
            if (reverse)
                builder.MustNot(ObjectFields.SignedBy.Be(positionId));
            else
                builder.Must(ObjectFields.SignedBy.Be(positionId));
            return builder;
        }

        /// <summary>
        /// Фильтрует документы, подписанные одной из указанных должностей
        /// </summary>
        /// <param name="builder">Построитель запросов</param>
        /// <param name="positionIds">Массив идентификаторов должностей</param>
        /// <param name="reverse">Если true — инвертировать условие</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterBySignedByMultiple(PQueryBuilder builder,
            int[] positionIds,
            bool reverse = false)
        {
            if (reverse)
                builder.MustNot(ObjectFields.SignedBy.BeAnyOf(positionIds));
            else
                builder.Must(ObjectFields.SignedBy.BeAnyOf(positionIds));
            return builder;
        }

        /// <summary>
        /// Фильтрует по идентификатору пользователя, изменившего состояние
        /// </summary>
        /// <param name="builder">Построитель запросов</param>
        /// <param name="personId">Идентификатор пользователя</param>
        /// <param name="reverse">Если true — инвертировать условие</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByStateChangedPersonId(PQueryBuilder builder,
            int personId,
            bool reverse = false)
        {
            if (reverse)
                builder.MustNot(ObjectFields.StateChangedPersonId.Be(personId));
            else
                builder.Must(ObjectFields.StateChangedPersonId.Be(personId));
            return builder;
        }

        /// <summary>
        /// Фильтрует по множеству пользователей, изменивших состояние
        /// </summary>
        /// <param name="builder">Построитель запросов</param>
        /// <param name="personIds">Массив идентификаторов пользователей</param>
        /// <param name="reverse">Если true — инвертировать условие</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByStateChangedPersonIds(PQueryBuilder builder,
            int[] personIds,
            bool reverse = false)
        {
            if (reverse)
                builder.MustNot(ObjectFields.StateChangedPersonId.BeAnyOf(personIds));
            else
                builder.Must(ObjectFields.StateChangedPersonId.BeAnyOf(personIds));
            return builder;
        }
    }
}