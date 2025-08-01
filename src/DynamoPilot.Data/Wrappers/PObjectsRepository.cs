using Ascon.Pilot.SDK;
using DynamoPilot.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamoPilot.Data.Wrappers
{
    public class PObjectsRepository : IWrapper
    {
        private readonly IObjectsRepository _objectsRepository;

        public PObjectsRepository(IObjectsRepository objectsRepository)
        {
            _objectsRepository = objectsRepository;

        }

        public override string ToString()
        {
            return "ObjectsRepository";
        }

        //public IDataObject GetCachedObject(Guid id)
        //{
        //    return _objectsRepository.GetCachedObject(id);
        //}

        public PPerson GetCurrentPerson()
        {
            return new(_objectsRepository.GetCurrentPerson());
        }

        public Guid GetDatabaseId()
        {
            return _objectsRepository.GetDatabaseId();
        }

        //public IObservable<IHistoryItem> GetHistoryItems(IEnumerable<Guid> ids)
        //{
        //    return _objectsRepository.GetHistoryItems(ids);
        //}

        public POrganisationUnit GetOrganisationUnit(int id)
        {
            return new(_objectsRepository.GetOrganisationUnit(id));
        }

        public IEnumerable<POrganisationUnit> GetOrganisationUnits()
        {
            return _objectsRepository.GetOrganisationUnits().Select(i => new POrganisationUnit(i));
        }

        public IEnumerable<PPerson> GetPeople()
        {
            return _objectsRepository.GetPeople().Select(p => new PPerson(p));
        }

        public PPerson GetPerson(int id)
        {
            return new(_objectsRepository.GetPerson(id));
        }

        //public IDataObject GetRootObject()
        //{
        //    return _objectsRepository.GetRootObject();
        //}

        public IEnumerable<PStorageDataObject> GetStorageObjects(IEnumerable<string> paths)
        {
            return _objectsRepository.GetStorageObjects(paths).Select(i => new PStorageDataObject(i));
        }

        public string GetStoragePath()
        {
            return _objectsRepository.GetStoragePath();
        }

        public string GetStoragePath(Guid objId)
        {
            return _objectsRepository.GetStoragePath(objId);
        }

        public PType GetType(int id)
        {
            return new(_objectsRepository.GetType(id));
        }

        public PType GetType(string name)
        {
            return new(_objectsRepository.GetType(name));
        }

        public IEnumerable<PType> GetTypes()
        {
            return _objectsRepository.GetTypes().Select(t => new PType(t));
        }

        public Task<ServerCommandRequestResult> InvokeServerCommandAsync(string commandName, byte[] data)
        {
            return _objectsRepository.InvokeServerCommandAsync(commandName, data);
        }

        public void Mount(Guid objId)
        {
            _objectsRepository.Mount(objId);
        }

        public Task MountAsync(Guid objId)
        {
            return _objectsRepository.MountAsync(objId);
        }

        //public IObservable<INotification> SubscribeNotification(NotificationKind kind)
        //{
        //    return _objectsRepository.SubscribeNotification(kind);
        //}

        //public IObservable<IDataObject> SubscribeObjects(IEnumerable<Guid> ids)
        //{
        //    return _objectsRepository.SubscribeObjects(ids);
        //}

        //public IObservable<IOrganisationUnit> SubscribeOrganisationUnits()
        //{
        //    return _objectsRepository.SubscribeOrganisationUnits();
        //}

        //public IObservable<IPerson> SubscribePeople()
        //{
        //    return _objectsRepository.SubscribePeople();
        //}

        //public IObservable<IStageObject> SubscribeStageObjects(IEnumerable<Guid> ids)
        //{
        //    return _objectsRepository.SubscribeStageObjects(ids);
        //}

        //public IObservable<ITaskMessage> SubscribeTaskMessages(IEnumerable<Guid> ids)
        //{
        //    return _objectsRepository.SubscribeTaskMessages(ids);
        //}

        //public IObservable<ITaskObject> SubscribeTasks(IEnumerable<Guid> ids)
        //{
        //    return _objectsRepository.SubscribeTasks(ids);
        //}

        //public IObservable<IType> SubscribeTypes()
        //{
        //    return _objectsRepository.SubscribeTypes();
        //}

        //public IObservable<IWorkflowObject> SubscribeWorkflow(IEnumerable<Guid> ids)
        //{
        //    return _objectsRepository.SubscribeWorkflow(ids);
        //}

        public object Unwrap()
        {
            return _objectsRepository;
        }
    }
}
