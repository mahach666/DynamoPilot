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

        public IAnnotationQueryBuilder GetAnnotationQueryBuilder()
        {
            return _searchService.GetAnnotationQueryBuilder();
        }

        public IQueryBuilder GetEmptyQueryBuilder()
        {
            return _searchService.GetEmptyQueryBuilder();
        }

        public IQueryBuilder GetObjectQueryBuilder()
        {
            return _searchService.GetObjectQueryBuilder();
        }

        public IQueryBuilder GetQueryBuilderFromTaskSearchExpression(string expression, bool invariantCulture, bool nonPersonalFilter)
        {
            return _searchService.GetQueryBuilderFromTaskSearchExpression(expression, invariantCulture, nonPersonalFilter);
        }

        public ISmartFolderQueryBuilder GetSmartFolderQueryBuilder()
        {
            return _searchService.GetSmartFolderQueryBuilder();
        }

        //public IQueryBuilder GetTaskQueryBuilder()
        //{
        //    return _searchService.GetTaskQueryBuilder();
        //}

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
