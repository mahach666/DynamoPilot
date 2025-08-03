using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;

namespace Search
{
    public static class SearchBuilder
    {
        [IsDesignScriptCompatible]
        public static PQueryBuilder CreateSearchBuilder(bool updater = false)
        {
            return new(StaticMetadata.SearchService.GetObjectQueryBuilder());
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder SetMaxResults(PQueryBuilder builder, int maxResults)
        {
            builder.MaxResults(maxResults);
            return builder;
        }

        //// Выполнение поиска
        //[IsDesignScriptCompatible]
        //public static IReadOnlyCollection<Guid> ExecuteSearch(PQueryBuilder builder)
        //{
        //    var searcher = new SynkSearcher((ISearchService)StaticMetadata.SearchService.Unwrap());
        //    return searcher.Search(builder, default);
        //}

        //[IsDesignScriptCompatible]
        //public static IReadOnlyCollection<Guid> ExecuteSearchWithMaxResults(PQueryBuilder builder, int maxResults)
        //{
        //    builder.MaxResults(maxResults);
        //    var searcher = new SynkSearcher((ISearchService)StaticMetadata.SearchService.Unwrap());
        //    return searcher.Search(builder, default);
        //}
    }
}