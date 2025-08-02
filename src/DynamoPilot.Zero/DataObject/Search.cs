using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.App.Utils;
using DynamoPilot.Data;
using System;
using System.Collections.Generic;

namespace DataObject
{
    public static class Search
    {
        [IsDesignScriptCompatible]
        public static IReadOnlyCollection<Guid> ByTypeId(int typeId)
        {
            IQueryBuilder builder = StaticMetadata.SearchService.GetObjectQueryBuilder();
            builder.MaxResults(int.MaxValue);
            builder.Must(ObjectFields.TypeId.Be(typeId));


            var searcher = new SynkSearcher((ISearchService)StaticMetadata.SearchService.Unwrap());

            var results = searcher.Search(builder, default);

            return results;
        }

        [IsDesignScriptCompatible]
        public static IReadOnlyCollection<Guid> ByTypeIdAndContext(int typeId, Guid contextId)
        {
            IQueryBuilder builder = StaticMetadata.SearchService.GetObjectQueryBuilder();
            builder.MaxResults(int.MaxValue);
            builder.Must(ObjectFields.Context.Be(contextId));
            builder.Must(ObjectFields.TypeId.Be(typeId));


            var searcher = new SynkSearcher((ISearchService)StaticMetadata.SearchService.Unwrap());

            var results = searcher.Search(builder, default);

            return results;
        }

        [IsDesignScriptCompatible]
        public static IReadOnlyCollection<Guid> ByTypeIdAndContext(int typeId, string contextId)
        {
            return ByTypeIdAndContext(typeId, Guid.Parse(contextId));
        }

        [IsDesignScriptCompatible]
        public static IReadOnlyCollection<Guid> ByTypeIdAndText(int typeId, string searchText)
        {
            IQueryBuilder builder = StaticMetadata.SearchService.GetObjectQueryBuilder();
            builder.MaxResults(int.MaxValue);
            builder.Must(ObjectFields.AllText.Be(searchText));
            builder.Must(ObjectFields.TypeId.Be(typeId));

            var searcher = new SynkSearcher((ISearchService)StaticMetadata.SearchService.Unwrap());

            var results = searcher.Search(builder, default);

            return results;
        }

        [IsDesignScriptCompatible]
        public static void Test()
        {
            IQueryBuilder builder = StaticMetadata.SearchService.GetObjectQueryBuilder();
            builder.MaxResults(int.MaxValue);
            builder.Must(ObjectFields.AllText.Be("test"));
            builder.Must(ObjectFields.TypeId.Be(18));

        }
    }
}