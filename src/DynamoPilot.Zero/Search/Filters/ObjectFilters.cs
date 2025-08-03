using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System;

namespace Search.Filters
{
    public static class ObjectFilters
    {
        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterById(PQueryBuilder builder, Guid id, bool reverse = false)
        {
            if (reverse)
                builder.MustNot(ObjectFields.Id.Be(id));
            else
                builder.Must(ObjectFields.Id.Be(id));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByIds(PQueryBuilder builder, Guid[] ids)
        {
            builder.Must(ObjectFields.Id.BeAnyOf(ids));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByParentId(PQueryBuilder builder, Guid parentId)
        {
            builder.Must(ObjectFields.ParentId.Be(parentId));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByParentIds(PQueryBuilder builder, Guid[] parentIds)
        {
            builder.Must(ObjectFields.ParentId.BeAnyOf(parentIds));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByTypeId(PQueryBuilder builder, int typeId, bool reverse = false)
        {
            if (reverse)
                builder.MustNot(ObjectFields.TypeId.Be(typeId));
            else
                builder.Must(ObjectFields.TypeId.Be(typeId));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByTypeIds(PQueryBuilder builder, int[] typeIds)
        {
            builder.Must(ObjectFields.TypeId.BeAnyOf(typeIds));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByObjectState(PQueryBuilder builder, string objectState)
        {
            if (Enum.TryParse<ObjectState>(objectState, out var state))
            {
                builder.Must(ObjectFields.ObjectState.Be(state));
            }
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByCreatorId(PQueryBuilder builder, int creatorId)
        {
            builder.Must(ObjectFields.CreatorId.Be(creatorId));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByCreatorIds(PQueryBuilder builder, int[] creatorIds)
        {
            builder.Must(ObjectFields.CreatorId.BeAnyOf(creatorIds));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByCreatedDateRange(PQueryBuilder builder, DateTime fromDate, DateTime toDate)
        {
            builder.Must(ObjectFields.CreatedDate.BeInRange(fromDate.ToUniversalTime(), toDate.ToUniversalTime()));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByIsSecret(PQueryBuilder builder, bool isSecret)
        {
            builder.Must(ObjectFields.IsSecret.Be(isSecret));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByAllText(PQueryBuilder builder, string searchText)
        {
            builder.Must(ObjectFields.AllText.Be(searchText));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByAllTextContainsAll(PQueryBuilder builder, string[] searchWords)
        {
            builder.Must(ObjectFields.AllText.ContainsAll(searchWords));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterBySnapshotsCreatedRange(PQueryBuilder builder, DateTime fromDate, DateTime toDate)
        {
            builder.Must(ObjectFields.SnapshotsCreated.BeInRange(fromDate.ToUniversalTime(), toDate.ToUniversalTime()));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByAllSnapshotsReason(PQueryBuilder builder, string reason)
        {
            builder.Must(ObjectFields.AllSnapshotsReason.Be(reason));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterBySignatureAwaitingBy(PQueryBuilder builder, int positionId)
        {
            builder.Must(ObjectFields.SignatureAwaitingBy.Be(positionId));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterBySignatureAwaitingByMultiple(PQueryBuilder builder, int[] positionIds)
        {
            builder.Must(ObjectFields.SignatureAwaitingBy.BeAnyOf(positionIds));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterBySignedBy(PQueryBuilder builder, int positionId)
        {
            builder.Must(ObjectFields.SignedBy.Be(positionId));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterBySignedByMultiple(PQueryBuilder builder, int[] positionIds)
        {
            builder.Must(ObjectFields.SignedBy.BeAnyOf(positionIds));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByStateChangedPersonId(PQueryBuilder builder, int personId)
        {
            builder.Must(ObjectFields.StateChangedPersonId.Be(personId));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByStateChangedPersonIds(PQueryBuilder builder, int[] personIds)
        {
            builder.Must(ObjectFields.StateChangedPersonId.BeAnyOf(personIds));
            return builder;
        }
    }
}