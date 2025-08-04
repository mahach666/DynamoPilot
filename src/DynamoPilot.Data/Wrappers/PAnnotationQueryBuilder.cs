using Ascon.Pilot.SDK;
using DynamoPilot.Data.Contracts;
using System.Collections.Generic;

namespace DynamoPilot.Data.Wrappers
{
    public class PAnnotationQueryBuilder : IWrapper
    {
        private readonly IAnnotationQueryBuilder _annotationQueryBuilder;

        public PAnnotationQueryBuilder(IAnnotationQueryBuilder annotationQueryBuilder)
        {
            _annotationQueryBuilder = annotationQueryBuilder;
        }

        public object Unwrap()
        {
            return _annotationQueryBuilder;
        }

        public PAnnotationQueryBuilder WithCurrentVersion()
        {
            _annotationQueryBuilder.WithCurrentVersion();
            return this;
        }

        public PAnnotationQueryBuilder WithKeyword(string keyword)
        {
            _annotationQueryBuilder.WithKeyword(keyword);
            return this;
        }

        public PAnnotationQueryBuilder WithQuotedKeyword(string keyword)
        {
            _annotationQueryBuilder.WithQuotedKeyword(keyword);
            return this;
        }

        public PAnnotationQueryBuilder WithType(int typeId)
        {
            _annotationQueryBuilder.WithType(typeId);
            return this;
        }

        public PAnnotationQueryBuilder WithTypes(IEnumerable<int> typeIds)
        {
            _annotationQueryBuilder.WithTypes(typeIds);
            return this;
        }
    }
}
