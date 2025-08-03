using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System;

namespace Search.Combinations
{
    public static class CommonSearches
    {
        [IsDesignScriptCompatible]
        public static PQueryBuilder SearchActiveDocuments(PQueryBuilder builder, int typeId)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            builder.MustNot(ObjectFields.ObjectState.Be(ObjectState.InRecycleBin));
            builder.MustNot(ObjectFields.ObjectState.Be(ObjectState.DeletedPermanently));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder SearchDocumentsByCreator(PQueryBuilder builder, int typeId, int creatorId)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(ObjectFields.CreatorId.Be(creatorId));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder SearchDocumentsByDateRange(PQueryBuilder builder, int typeId, DateTime fromDate, DateTime toDate)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(ObjectFields.CreatedDate.BeInRange(fromDate.ToUniversalTime(), toDate.ToUniversalTime()));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder SearchDocumentsByText(PQueryBuilder builder, int typeId, string searchText)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(ObjectFields.AllText.Be(searchText));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder SearchRecentDocuments(PQueryBuilder builder, int typeId, int daysBack)
        {
            var fromDate = DateTime.Now.AddDays(-daysBack);
            var toDate = DateTime.Now;
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(ObjectFields.CreatedDate.BeInRange(fromDate.ToUniversalTime(), toDate.ToUniversalTime()));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder SearchDocumentsThisMonth(PQueryBuilder builder, int typeId)
        {
            var startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(ObjectFields.CreatedDate.BeInRange(startOfMonth.ToUniversalTime(), endOfMonth.ToUniversalTime()));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder SearchDocumentsThisYear(PQueryBuilder builder, int typeId)
        {
            var startOfYear = new DateTime(DateTime.Now.Year, 1, 1);
            var endOfYear = new DateTime(DateTime.Now.Year, 12, 31);
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(ObjectFields.CreatedDate.BeInRange(startOfYear.ToUniversalTime(), endOfYear.ToUniversalTime()));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder SearchSignedDocuments(PQueryBuilder builder, int typeId, int positionId)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(ObjectFields.SignedBy.Be(positionId));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder SearchDocumentsAwaitingSignature(PQueryBuilder builder, int typeId, int positionId)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(ObjectFields.SignatureAwaitingBy.Be(positionId));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder SearchLockedDocuments(PQueryBuilder builder, int typeId, int personId)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.LockRequested, ObjectState.LockAccepted));
            builder.Must(ObjectFields.StateChangedPersonId.Be(personId));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder SearchDocumentsByAttribute(PQueryBuilder builder, int typeId, string attributeName, string attributeValue)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(AttributeFields.String(attributeName).Be(attributeValue));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder SearchDocumentsByMultipleTypes(PQueryBuilder builder, int[] typeIds)
        {
            builder.Must(ObjectFields.TypeId.BeAnyOf(typeIds));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder SearchDocumentsByMultipleCreators(PQueryBuilder builder, int typeId, int[] creatorIds)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(ObjectFields.CreatorId.BeAnyOf(creatorIds));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder SearchDocumentsByTextContainsAll(PQueryBuilder builder, int typeId, string[] searchWords)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(ObjectFields.AllText.ContainsAll(searchWords));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder SearchDocumentsByAttributeRange(PQueryBuilder builder, int typeId, string attributeName, double fromValue, double toValue)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(AttributeFields.Double(attributeName).BeInRange(fromValue, toValue));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder SearchDocumentsByAttributeDateRange(PQueryBuilder builder, int typeId, string attributeName, DateTime fromDate, DateTime toDate)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(AttributeFields.DateTime(attributeName).BeInRange(fromDate.ToUniversalTime(), toDate.ToUniversalTime()));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder SearchDocumentsByBooleanAttribute(PQueryBuilder builder, int typeId, string attributeName, bool attributeValue)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(AttributeFields.Bool(attributeName).Be(attributeValue));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder SearchDocumentsInRecycleBin(PQueryBuilder builder, int typeId)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(ObjectFields.ObjectState.Be(ObjectState.InRecycleBin));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder SearchFrozenDocuments(PQueryBuilder builder, int typeId)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(ObjectFields.ObjectState.Be(ObjectState.Frozen));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder SearchPublicDocuments(PQueryBuilder builder, int typeId)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(ObjectFields.IsSecret.Be(false));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder SearchSecretDocuments(PQueryBuilder builder, int typeId)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(ObjectFields.IsSecret.Be(true));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            return builder;
        }
    }
} 