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