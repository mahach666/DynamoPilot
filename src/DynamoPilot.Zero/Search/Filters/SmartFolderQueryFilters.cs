using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System;
using System.Collections.Generic;

namespace Search.Filters
{
    /// <summary>
    /// Ноды для фильтрации в умных папках
    /// </summary>
    public static class SmartFolderQueryFilters
    {
        [IsDesignScriptCompatible]
        public static PSmartFolderQueryBuilder WithAuthor(PSmartFolderQueryBuilder smartFolderQueryBuilder,
            int authorId)
        {
            smartFolderQueryBuilder.WithAuthor(authorId);
            return smartFolderQueryBuilder;
        }

        [IsDesignScriptCompatible]
        public static PSmartFolderQueryBuilder WithAuthors(PSmartFolderQueryBuilder smartFolderQueryBuilder,
            IEnumerable<int> authorIds)
        {
            smartFolderQueryBuilder.WithAuthors(authorIds);
            return smartFolderQueryBuilder;
        }

        [IsDesignScriptCompatible]
        public static PSmartFolderQueryBuilder WithCreatedInRange(PSmartFolderQueryBuilder smartFolderQueryBuilder,
            DateTime fromUtc,
            DateTime toUtc)
        {
            smartFolderQueryBuilder.WithCreatedInRange(fromUtc, toUtc);
            return smartFolderQueryBuilder;
        }

        [IsDesignScriptCompatible]
        public static PSmartFolderQueryBuilder WithCreatedLastMonth(PSmartFolderQueryBuilder smartFolderQueryBuilder)
        {
            smartFolderQueryBuilder.WithCreatedLastMonth();
            return smartFolderQueryBuilder;
        }

        [IsDesignScriptCompatible]
        public static PSmartFolderQueryBuilder WithCreatedLastWeek(PSmartFolderQueryBuilder smartFolderQueryBuilder)
        {
            smartFolderQueryBuilder.WithCreatedLastWeek();
            return smartFolderQueryBuilder;
        }

        [IsDesignScriptCompatible]
        public static PSmartFolderQueryBuilder WithCreatedLastYear(PSmartFolderQueryBuilder smartFolderQueryBuilder)
        {
            smartFolderQueryBuilder.WithCreatedLastYear();
            return smartFolderQueryBuilder;
        }

        [IsDesignScriptCompatible]
        public static PSmartFolderQueryBuilder WithCreatedThisMonth(PSmartFolderQueryBuilder smartFolderQueryBuilder)
        {
            smartFolderQueryBuilder.WithCreatedThisMonth();
            return smartFolderQueryBuilder;
        }

        [IsDesignScriptCompatible]
        public static PSmartFolderQueryBuilder WithCreatedThisWeek(PSmartFolderQueryBuilder smartFolderQueryBuilder)
        {
            smartFolderQueryBuilder.WithCreatedThisWeek();
            return smartFolderQueryBuilder;
        }

        [IsDesignScriptCompatible]

        public static PSmartFolderQueryBuilder WithCreatedThisYear(PSmartFolderQueryBuilder smartFolderQueryBuilder)
        {
            smartFolderQueryBuilder.WithCreatedThisYear();
            return smartFolderQueryBuilder;
        }

        [IsDesignScriptCompatible]
        public static PSmartFolderQueryBuilder WithCreatedToday(PSmartFolderQueryBuilder smartFolderQueryBuilder)
        {
            smartFolderQueryBuilder.WithCreatedToday();
            return smartFolderQueryBuilder;
        }

        [IsDesignScriptCompatible]
        public static PSmartFolderQueryBuilder WithCreatedYesterday(PSmartFolderQueryBuilder smartFolderQueryBuilder)
        {
            smartFolderQueryBuilder.WithCreatedYesterday();
            return smartFolderQueryBuilder;
        }

        [IsDesignScriptCompatible]
        public static PSmartFolderQueryBuilder WithKeyword(PSmartFolderQueryBuilder smartFolderQueryBuilder,
            string keyword)
        {
            smartFolderQueryBuilder.WithKeyword(keyword);
            return smartFolderQueryBuilder;
        }

        [IsDesignScriptCompatible]
        public static PSmartFolderQueryBuilder WithQuotedKeyword(PSmartFolderQueryBuilder smartFolderQueryBuilder,
            string keyword)
        {
            smartFolderQueryBuilder.WithQuotedKeyword(keyword);
            return smartFolderQueryBuilder;
        }

        [IsDesignScriptCompatible]
        public static PSmartFolderQueryBuilder WithSearchMode(PSmartFolderQueryBuilder smartFolderQueryBuilder,
            SearchMode searchMode)
        {
            smartFolderQueryBuilder.WithSearchMode(searchMode);
            return smartFolderQueryBuilder;
        }

        [IsDesignScriptCompatible]
        public static PSmartFolderQueryBuilder WithState(PSmartFolderQueryBuilder smartFolderQueryBuilder,
            ObjectState state)
        {
            smartFolderQueryBuilder.WithState(state);
            return smartFolderQueryBuilder;
        }

        [IsDesignScriptCompatible]
        public static PSmartFolderQueryBuilder WithType(PSmartFolderQueryBuilder smartFolderQueryBuilder, int typeId)
        {
            smartFolderQueryBuilder.WithType(typeId);
            return smartFolderQueryBuilder;
        }

        [IsDesignScriptCompatible]
        public static PSmartFolderQueryBuilder WithTypes(PSmartFolderQueryBuilder smartFolderQueryBuilder,
            IEnumerable<int> typeIds)
        {
            smartFolderQueryBuilder.WithTypes(typeIds);
            return smartFolderQueryBuilder;
        }
    }
}
