using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.App.Utils;
using DynamoPilot.Data;
using System;
using System.Collections.Generic;

namespace Search
{
    public static class SearchBuilder
    {
        [IsDesignScriptCompatible]
        public static IQueryBuilder CreateSearchBuilder()
        {
            return StaticMetadata.SearchService.GetObjectQueryBuilder();
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder SetMaxResults(IQueryBuilder builder, int maxResults)
        {
            builder.MaxResults(maxResults);
            return builder;
        }

        // Выполнение поиска
        [IsDesignScriptCompatible]
        public static IReadOnlyCollection<Guid> ExecuteSearch(IQueryBuilder builder)
        {
            var searcher = new SynkSearcher((ISearchService)StaticMetadata.SearchService.Unwrap());
            return searcher.Search(builder, default);
        }

        [IsDesignScriptCompatible]
        public static IReadOnlyCollection<Guid> ExecuteSearchWithMaxResults(IQueryBuilder builder, int maxResults)
        {
            builder.MaxResults(maxResults);
            var searcher = new SynkSearcher((ISearchService)StaticMetadata.SearchService.Unwrap());
            return searcher.Search(builder, default);
        }
    }
} 