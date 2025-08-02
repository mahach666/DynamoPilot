using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.App.Utils;
using DynamoPilot.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataObject
{
    public static class SearchHelpers
    {
        // ===== УДОБНЫЕ НОДЫ ДЛЯ РАБОТЫ С ДАТАМИ =====

        [IsDesignScriptCompatible]
        public static DateTime GetToday()
        {
            return DateTime.Today;
        }

        [IsDesignScriptCompatible]
        public static DateTime GetNow()
        {
            return DateTime.Now;
        }

        [IsDesignScriptCompatible]
        public static DateTime AddDays(DateTime date, int days)
        {
            return date.AddDays(days);
        }

        [IsDesignScriptCompatible]
        public static DateTime SubtractDays(DateTime date, int days)
        {
            return date.AddDays(-days);
        }

        [IsDesignScriptCompatible]
        public static DateTime AddMonths(DateTime date, int months)
        {
            return date.AddMonths(months);
        }

        [IsDesignScriptCompatible]
        public static DateTime AddYears(DateTime date, int years)
        {
            return date.AddYears(years);
        }

        [IsDesignScriptCompatible]
        public static DateTime GetStartOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        [IsDesignScriptCompatible]
        public static DateTime GetEndOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        }

        [IsDesignScriptCompatible]
        public static DateTime GetStartOfYear(DateTime date)
        {
            return new DateTime(date.Year, 1, 1);
        }

        [IsDesignScriptCompatible]
        public static DateTime GetEndOfYear(DateTime date)
        {
            return new DateTime(date.Year, 12, 31);
        }

        // ===== ГОТОВЫЕ КОМБИНАЦИИ ФИЛЬТРОВ =====

        [IsDesignScriptCompatible]
        public static IQueryBuilder SearchActiveDocuments(IQueryBuilder builder, int typeId)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            builder.MustNot(ObjectFields.ObjectState.Be(ObjectState.Deleted));
            builder.MustNot(ObjectFields.ObjectState.Be(ObjectState.InRecycleBin));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder SearchDocumentsByCreator(IQueryBuilder builder, int typeId, int creatorId)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(ObjectFields.CreatorId.Be(creatorId));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder SearchDocumentsByDateRange(IQueryBuilder builder, int typeId, DateTime fromDate, DateTime toDate)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(ObjectFields.CreatedDate.BeInRange(fromDate.ToUniversalTime(), toDate.ToUniversalTime()));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder SearchDocumentsByText(IQueryBuilder builder, int typeId, string searchText)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(ObjectFields.AllText.Be(searchText));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder SearchRecentDocuments(IQueryBuilder builder, int typeId, int daysBack)
        {
            var fromDate = DateTime.Now.AddDays(-daysBack);
            var toDate = DateTime.Now;
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(ObjectFields.CreatedDate.BeInRange(fromDate.ToUniversalTime(), toDate.ToUniversalTime()));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder SearchDocumentsThisMonth(IQueryBuilder builder, int typeId)
        {
            var startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(ObjectFields.CreatedDate.BeInRange(startOfMonth.ToUniversalTime(), endOfMonth.ToUniversalTime()));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder SearchDocumentsThisYear(IQueryBuilder builder, int typeId)
        {
            var startOfYear = new DateTime(DateTime.Now.Year, 1, 1);
            var endOfYear = new DateTime(DateTime.Now.Year, 12, 31);
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(ObjectFields.CreatedDate.BeInRange(startOfYear.ToUniversalTime(), endOfYear.ToUniversalTime()));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder SearchSignedDocuments(IQueryBuilder builder, int typeId, int positionId)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(ObjectFields.SignedBy.Be(positionId));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder SearchDocumentsAwaitingSignature(IQueryBuilder builder, int typeId, int positionId)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(ObjectFields.SignatureAwaitingBy.Be(positionId));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder SearchLockedDocuments(IQueryBuilder builder, int typeId, int personId)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.LockRequested, ObjectState.LockAccepted));
            builder.Must(ObjectFields.StateChangedPersonId.Be(personId));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder SearchDocumentsByAttribute(IQueryBuilder builder, int typeId, string attributeName, string attributeValue)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(AttributeFields.String(attributeName).Be(attributeValue));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder SearchDocumentsByMultipleTypes(IQueryBuilder builder, int[] typeIds)
        {
            builder.Must(ObjectFields.TypeId.BeAnyOf(typeIds));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder SearchDocumentsByMultipleCreators(IQueryBuilder builder, int typeId, int[] creatorIds)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(ObjectFields.CreatorId.BeAnyOf(creatorIds));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder SearchDocumentsByTextContainsAll(IQueryBuilder builder, int typeId, string[] searchWords)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(ObjectFields.AllText.ContainsAll(searchWords));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder SearchDocumentsByAttributeRange(IQueryBuilder builder, int typeId, string attributeName, double fromValue, double toValue)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(AttributeFields.Double(attributeName).BeInRange(fromValue, toValue));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder SearchDocumentsByAttributeDateRange(IQueryBuilder builder, int typeId, string attributeName, DateTime fromDate, DateTime toDate)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(AttributeFields.DateTime(attributeName).BeInRange(fromDate.ToUniversalTime(), toDate.ToUniversalTime()));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder SearchDocumentsByBooleanAttribute(IQueryBuilder builder, int typeId, string attributeName, bool attributeValue)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(AttributeFields.Bool(attributeName).Be(attributeValue));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder SearchDocumentsInRecycleBin(IQueryBuilder builder, int typeId)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(ObjectFields.ObjectState.Be(ObjectState.InRecycleBin));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder SearchFrozenDocuments(IQueryBuilder builder, int typeId)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(ObjectFields.ObjectState.Be(ObjectState.Frozen));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder SearchPublicDocuments(IQueryBuilder builder, int typeId)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(ObjectFields.IsSecret.Be(false));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder SearchSecretDocuments(IQueryBuilder builder, int typeId)
        {
            builder.Must(ObjectFields.TypeId.Be(typeId));
            builder.Must(ObjectFields.IsSecret.Be(true));
            builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
            return builder;
        }

        // ===== УТИЛИТЫ ДЛЯ РАБОТЫ С РЕЗУЛЬТАТАМИ =====

        [IsDesignScriptCompatible]
        public static int GetResultCount(IReadOnlyCollection<Guid> results)
        {
            return results?.Count ?? 0;
        }

        [IsDesignScriptCompatible]
        public static bool HasResults(IReadOnlyCollection<Guid> results)
        {
            return results?.Count > 0;
        }

        [IsDesignScriptCompatible]
        public static Guid GetFirstResult(IReadOnlyCollection<Guid> results)
        {
            return results?.FirstOrDefault() ?? Guid.Empty;
        }

        [IsDesignScriptCompatible]
        public static Guid[] GetResultsArray(IReadOnlyCollection<Guid> results)
        {
            return results?.ToArray() ?? new Guid[0];
        }

        [IsDesignScriptCompatible]
        public static List<Guid> GetResultsList(IReadOnlyCollection<Guid> results)
        {
            return results?.ToList() ?? new List<Guid>();
        }

        // ===== КОНСТАНТЫ ДЛЯ СОСТОЯНИЙ ОБЪЕКТОВ =====

        [IsDesignScriptCompatible]
        public static string GetObjectStateAlive()
        {
            return ObjectState.Alive.ToString();
        }

        [IsDesignScriptCompatible]
        public static string GetObjectStateFrozen()
        {
            return ObjectState.Frozen.ToString();
        }

        [IsDesignScriptCompatible]
        public static string GetObjectStateDeleted()
        {
            return ObjectState.Deleted.ToString();
        }

        [IsDesignScriptCompatible]
        public static string GetObjectStateInRecycleBin()
        {
            return ObjectState.InRecycleBin.ToString();
        }

        [IsDesignScriptCompatible]
        public static string GetObjectStateLockRequested()
        {
            return ObjectState.LockRequested.ToString();
        }

        [IsDesignScriptCompatible]
        public static string GetObjectStateLockAccepted()
        {
            return ObjectState.LockAccepted.ToString();
        }

        [IsDesignScriptCompatible]
        public static string[] GetAllObjectStates()
        {
            return Enum.GetNames(typeof(ObjectState));
        }
    }
} 