//using Ascon.Pilot.SDK;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace DynamoPilot.App.Utils
//{
//    class Searcher : IObserver<ISearchResult>
//    {
//        private readonly IObjectsRepository _repository;
//        private TaskCompletionSource<List<IDataObject>> _tcs;
//        private IDisposable _subscription;

//        public Searcher(IObjectsRepository repository)
//        {
//            _repository = repository;
//        }

//        public Task<List<IDataObject>> GetRes(ISearchService searchService, IQueryBuilder builder)
//        {
//            _tcs = new TaskCompletionSource<List<IDataObject>>();
//            _subscription = searchService.Search(builder).Subscribe(this);
//            return _tcs.Task;
//        }

//        async void IObserver<ISearchResult>.OnNext(ISearchResult value)
//        {
//            try
//            {
//                if (value.Kind == SearchResultKind.Remote)
//                    return;

//                var res = new List<IDataObject>();

//                foreach (var id in value.Result)
//                {
//                    var loader = new ObjectLoader(_repository);
//                    var obj = await loader.Load(id);
//                    res.Add(obj);
//                }
//                _tcs?.TrySetResult(res);
//            }
//            catch (Exception e)
//            {
//                _tcs?.TrySetException(e);
//            }
//            finally
//            {
//                _subscription?.Dispose();
//            }
//        }

//        void IObserver<ISearchResult>.OnCompleted()
//        {
//            _tcs.TrySetResult(new List<IDataObject>());
//            _subscription?.Dispose();
//        }

//        void IObserver<ISearchResult>.OnError(Exception error)
//        {
//            _tcs?.TrySetException(error);
//            _subscription?.Dispose();
//        }
//    }
//}
