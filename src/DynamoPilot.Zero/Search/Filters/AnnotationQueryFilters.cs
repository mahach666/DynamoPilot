using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System.Collections.Generic;

namespace Search.Filters
{
    public static class AnnotationQueryFilters
    {
        [IsDesignScriptCompatible]
        public static PAnnotationQueryBuilder WithCurrentVersion(PAnnotationQueryBuilder pAnnotationQueryBuilder)
        {
            pAnnotationQueryBuilder.WithCurrentVersion();
            return pAnnotationQueryBuilder;
        }

        [IsDesignScriptCompatible]
        public static PAnnotationQueryBuilder WithKeyword(PAnnotationQueryBuilder pAnnotationQueryBuilder , string keyword)
        {
            pAnnotationQueryBuilder.WithKeyword(keyword);
            return pAnnotationQueryBuilder;
        }

        [IsDesignScriptCompatible]
        public static PAnnotationQueryBuilder WithQuotedKeyword(PAnnotationQueryBuilder pAnnotationQueryBuilder,string keyword)
        {
            pAnnotationQueryBuilder.WithQuotedKeyword(keyword);
            return pAnnotationQueryBuilder;
        }

        [IsDesignScriptCompatible]
        public static PAnnotationQueryBuilder WithType(PAnnotationQueryBuilder pAnnotationQueryBuilder,int typeId)
        {
            pAnnotationQueryBuilder.WithType(typeId);
            return pAnnotationQueryBuilder;
        }

        [IsDesignScriptCompatible]
        public static PAnnotationQueryBuilder WithTypes(PAnnotationQueryBuilder pAnnotationQueryBuilder, IEnumerable<int> typeIds)
        {
            pAnnotationQueryBuilder.WithTypes(typeIds);
            return pAnnotationQueryBuilder;
        }
    }
}
