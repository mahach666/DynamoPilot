using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;

namespace Search
{
    public static class SearchBuilder
    {
        [IsDesignScriptCompatible]
        public static PQueryBuilder CreateObjectQueryBuilder(bool updater = false)
        {
            return StaticMetadata.SearchService.GetObjectQueryBuilder();
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder CreateEmptyQueryBuilder(bool updater = false)
        {
            return StaticMetadata.SearchService.GetEmptyQueryBuilder();
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder CreateTaskQueryBuilder(bool updater = false)
        {
            return StaticMetadata.SearchService.GetTaskQueryBuilder();
        }

        [IsDesignScriptCompatible]
        public static PAnnotationQueryBuilder CreateAnnotationQueryBuilder(bool updater = false)
        {
            return StaticMetadata.SearchService.GetAnnotationQueryBuilder();
        }

        [IsDesignScriptCompatible]
        public static PSmartFolderQueryBuilder CreateSmartFolderQueryBuilder(bool updater = false)
        {
            return StaticMetadata.SearchService.GetSmartFolderQueryBuilder();
        }

        //[IsDesignScriptCompatible]
        //public static PQueryBuilder CreateQueryBuilderFromTaskSearchExpression(bool updater = false)
        //{
        //    return StaticMetadata.SearchService.GetQueryBuilderFromTaskSearchExpression();
        //}

        [IsDesignScriptCompatible]
        public static PQueryBuilder SetMaxResults(PQueryBuilder builder, int maxResults)
        {
            builder.MaxResults(maxResults);
            return builder;
        }
    }
}