using Ascon.Pilot.SDK;
using DynamoPilot.Data.Contracts;

namespace DynamoPilot.Data.Wrappers
{
    public class PSearchService : IWrapper
    {
        private readonly ISearchService _searchService;

        public PSearchService(ISearchService searchService)
        {
            _searchService = searchService;
        }

        //public void Dispose()
        //{
        //   _searchService.;
        //}

        public PAnnotationQueryBuilder GetAnnotationQueryBuilder()
        {
            return new(_searchService.GetAnnotationQueryBuilder());
        }

        public PQueryBuilder GetEmptyQueryBuilder()
        {
            return new(_searchService.GetEmptyQueryBuilder());
        }

        public PQueryBuilder GetObjectQueryBuilder()
        {
            return new(_searchService.GetObjectQueryBuilder());
        }

        //public PQueryBuilder GetQueryBuilderFromTaskSearchExpression(string expression, bool invariantCulture, bool nonPersonalFilter)
        //{
        //    return new(_searchService.GetQueryBuilderFromTaskSearchExpression(expression, invariantCulture, nonPersonalFilter));
        //}

        public PSmartFolderQueryBuilder GetSmartFolderQueryBuilder()
        {
            return new(_searchService.GetSmartFolderQueryBuilder());
        }

        public PQueryBuilder GetTaskQueryBuilder()
        {
            return new(_searchService.GetTaskQueryBuilder());
        }

        //public IObservable<ISearchResult> RunRefreshableSearch(IQueryBuilder query)
        //{
        //    return _searchService.;
        //}

        //public IObservable<ISearchResult> Search(IQueryBuilder query)
        //{
        //    return _searchService.;
        //}

        public object Unwrap()
        {
            return _searchService;
        }
    }
}
