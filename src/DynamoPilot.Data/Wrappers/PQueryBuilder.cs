using Ascon.Pilot.SDK;
using DynamoPilot.Data.Contracts;
using System;
using System.ComponentModel;

namespace DynamoPilot.Data.Wrappers
{
    public class PQueryBuilder : IWrapper
    {
        private readonly IQueryBuilder _queryBuilder;
        public PQueryBuilder(IQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder;
        }

        public PQueryBuilder AppendPlainQuery(string luceneQuery)
        {
            _queryBuilder.AppendPlainQuery(luceneQuery);
            return this;
        }

        public (string luceneQuery, string typeFilter) Build()
        {
            return _queryBuilder.Build();
        }

        public PQueryBuilder InContext(Guid id)
        {
            _queryBuilder.InContext(id);
            return this;
        }

        public PQueryBuilder MaxResults(int result)
        {
            _queryBuilder.MaxResults(result);
            return this;
        }

        public PQueryBuilder Must(ISearchTerm term)
        {
            _queryBuilder.Must(term);
            return this;
        }

        public PQueryBuilder MustAnyOf(params ISearchTerm[] terms)
        {
            _queryBuilder.MustAnyOf(terms);
            return this;
        }

        public PQueryBuilder MustNot(ISearchTerm term)
        {
            _queryBuilder.MustNot(term);
            return this;
        }

        public PQueryBuilder SortBy(INamedField field, ListSortDirection direction)
        {
            _queryBuilder.SortBy(field, direction);
            return this;
        }
        public PQueryBuilder WithTypeFilter(string typeFilter)
        {
            _queryBuilder.WithTypeFilter(typeFilter);
            return this;
        }

        public object Unwrap()
        {
            return _queryBuilder;
        }
    }
}
