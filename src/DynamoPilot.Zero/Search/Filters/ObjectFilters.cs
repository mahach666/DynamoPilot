using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using System;

namespace Search.Filters
{
    public static class ObjectFilters
    {
        [IsDesignScriptCompatible]
        public static IQueryBuilder FilterById(IQueryBuilder builder, Guid id)
        {
            builder.Must(ObjectFields.Id.Be(id));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder FilterByIds(IQueryBuilder builder, Guid[] ids)
        {
            builder.Must(ObjectFields.Id.BeAnyOf(ids));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder FilterByParentId(IQueryBuilder builder, Guid parentId)
        {
            builder.Must(ObjectFields.ParentId.Be(parentId));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder FilterByParentIds(IQueryBuilder builder, Guid[] parentIds)
        {
            builder.Must(ObjectFields.ParentId.BeAnyOf(parentIds));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder FilterByTypeId(IQueryBuilder builder, int typeId)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder FilterByTypeIds(IQueryBuilder builder, int[] typeIds)
        {
            builder.Must(ObjectFields.TypeId.BeAnyOf(typeIds));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder FilterByObjectState(IQueryBuilder builder, string objectState)
        {
            if (Enum.TryParse<ObjectState>(objectState, out var state))
            {
                builder.Must(ObjectFields.ObjectState.Be(state));
            }
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder FilterByCreatorId(IQueryBuilder builder, int creatorId)
        {
            builder.Must(ObjectFields.CreatorId.Be(creatorId));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder FilterByCreatorIds(IQueryBuilder builder, int[] creatorIds)
        {
            builder.Must(ObjectFields.CreatorId.BeAnyOf(creatorIds));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder FilterByCreatedDateRange(IQueryBuilder builder, DateTime fromDate, DateTime toDate)
        {
            builder.Must(ObjectFields.CreatedDate.BeInRange(fromDate.ToUniversalTime(), toDate.ToUniversalTime()));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder FilterByIsSecret(IQueryBuilder builder, bool isSecret)
        {
            builder.Must(ObjectFields.IsSecret.Be(isSecret));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder FilterByAllText(IQueryBuilder builder, string searchText)
        {
            builder.Must(ObjectFields.AllText.Be(searchText));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder FilterByAllTextContainsAll(IQueryBuilder builder, string[] searchWords)
        {
            builder.Must(ObjectFields.AllText.ContainsAll(searchWords));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder FilterBySnapshotsCreatedRange(IQueryBuilder builder, DateTime fromDate, DateTime toDate)
        {
            builder.Must(ObjectFields.SnapshotsCreated.BeInRange(fromDate.ToUniversalTime(), toDate.ToUniversalTime()));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder FilterByAllSnapshotsReason(IQueryBuilder builder, string reason)
        {
            builder.Must(ObjectFields.AllSnapshotsReason.Be(reason));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder FilterBySignatureAwaitingBy(IQueryBuilder builder, int positionId)
        {
            builder.Must(ObjectFields.SignatureAwaitingBy.Be(positionId));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder FilterBySignatureAwaitingByMultiple(IQueryBuilder builder, int[] positionIds)
        {
            builder.Must(ObjectFields.SignatureAwaitingBy.BeAnyOf(positionIds));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder FilterBySignedBy(IQueryBuilder builder, int positionId)
        {
            builder.Must(ObjectFields.SignedBy.Be(positionId));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder FilterBySignedByMultiple(IQueryBuilder builder, int[] positionIds)
        {
            builder.Must(ObjectFields.SignedBy.BeAnyOf(positionIds));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder FilterByStateChangedPersonId(IQueryBuilder builder, int personId)
        {
            builder.Must(ObjectFields.StateChangedPersonId.Be(personId));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder FilterByStateChangedPersonIds(IQueryBuilder builder, int[] personIds)
        {
            builder.Must(ObjectFields.StateChangedPersonId.BeAnyOf(personIds));
            return builder;
        }
    }
} 