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

        public IQueryBuilder AppendPlainQuery(string luceneQuery)
        {
            return _queryBuilder.AppendPlainQuery(luceneQuery);
        }

        public (string luceneQuery, string typeFilter) Build()
        {
            return _queryBuilder.Build();
        }

        public IQueryBuilder InContext(Guid id)
        {
            return _queryBuilder.InContext(id);
        }

        public IQueryBuilder MaxResults(int result)
        {
            return _queryBuilder.MaxResults(result);
        }

        public IQueryBuilder Must(ISearchTerm term)
        {
            return _queryBuilder.Must(term);
        }

        public IQueryBuilder MustAnyOf(params ISearchTerm[] terms)
        {
            return _queryBuilder.MustAnyOf(terms);
        }

        public IQueryBuilder MustNot(ISearchTerm term)
        {
            return _queryBuilder.MustNot(term);
        }

        public IQueryBuilder SortBy(INamedField field, ListSortDirection direction)
        {
            return _queryBuilder.SortBy(field, direction);
        }
        public IQueryBuilder WithTypeFilter(string typeFilter)
        {
            return _queryBuilder.WithTypeFilter(typeFilter);
        }

        public object Unwrap()
        {
            return _queryBuilder;
        }
    }
}
