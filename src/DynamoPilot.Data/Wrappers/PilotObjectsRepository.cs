using Ascon.Pilot.SDK;
using Ascon.Pilot.SDK.Data;
using DynamoPilot.App.Utils;
using DynamoPilot.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamoPilot.Data.Wrappers
{
    public class PilotObjectsRepository : IWrapper
    {
        private readonly IObjectsRepository _objectsRepository;
        public PilotObjectsRepository(IObjectsRepository objectsRepository)
        {
            _objectsRepository = objectsRepository;
        }

        public override string ToString()
        {
            return "ObjectsRepository";
        }

        public PilotDataObject GetObject(string id)
        {
            //var loader = new ObjectLoader(_objectsRepository);
            //return new PilotDataObject (await loader.Load(new Guid(id)));

            var res = PilotSync.LoadObjSync(_objectsRepository, new Guid(id));
            return new PilotDataObject(res);
        }
        //public IDataObject GetCachedObject(Guid id)
        //{
        //    return _objectsRepository.GetCachedObject(id);
        //}

        public PilotPerson GetCurrentPerson()
        {
            return new PilotPerson(_objectsRepository.GetCurrentPerson());
        }

        public Guid GetDatabaseId()
        {
            return _objectsRepository.GetDatabaseId();
        }

        public IObservable<IHistoryItem> GetHistoryItems(IEnumerable<Guid> ids)
        {
            return _objectsRepository.GetHistoryItems(ids);
        }

        public IOrganisationUnit GetOrganisationUnit(int id)
        {
            return _objectsRepository.GetOrganisationUnit(id);
        }

        public IEnumerable<IOrganisationUnit> GetOrganisationUnits()
        {
            return _objectsRepository.GetOrganisationUnits();
        }

        public IEnumerable<PilotPerson> GetPeople()
        {
            return _objectsRepository.GetPeople().Select(p => new PilotPerson(p));
        }

        public PilotPerson GetPerson(int id)
        {
            return new PilotPerson(_objectsRepository.GetPerson(id));
        }

        public IDataObject GetRootObject()
        {
            return _objectsRepository.GetRootObject();
        }

        public IEnumerable<IStorageDataObject> GetStorageObjects(IEnumerable<string> paths)
        {
            return _objectsRepository.GetStorageObjects(paths);
        }

        public string GetStoragePath()
        {
            return _objectsRepository.GetStoragePath();
        }

        public string GetStoragePath(Guid objId)
        {
            return _objectsRepository.GetStoragePath(objId);
        }

        public PilotType GetType(int id)
        {
            return new PilotType(_objectsRepository.GetType(id));
        }

        public PilotType GetType(string name)
        {
            return new PilotType(_objectsRepository.GetType(name));
        }

        public IEnumerable<PilotType> GetTypes()
        {
            return _objectsRepository.GetTypes().Select(t => new PilotType(t));
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

        public IObservable<INotification> SubscribeNotification(NotificationKind kind)
        {
            return _objectsRepository.SubscribeNotification(kind);
        }

        public IObservable<IDataObject> SubscribeObjects(IEnumerable<Guid> ids)
        {
            return _objectsRepository.SubscribeObjects(ids);
        }

        public IObservable<IOrganisationUnit> SubscribeOrganisationUnits()
        {
            return _objectsRepository.SubscribeOrganisationUnits();
        }

        public IObservable<IPerson> SubscribePeople()
        {
            return _objectsRepository.SubscribePeople();
        }

        //public IObservable<IStageObject> SubscribeStageObjects(IEnumerable<Guid> ids)
        //{
        //    return _objectsRepository.SubscribeStageObjects(ids);
        //}

        public IObservable<ITaskMessage> SubscribeTaskMessages(IEnumerable<Guid> ids)
        {
            return _objectsRepository.SubscribeTaskMessages(ids);
        }

        //public IObservable<ITaskObject> SubscribeTasks(IEnumerable<Guid> ids)
        //{
        //    return _objectsRepository.SubscribeTasks(ids);
        //}

        public IObservable<IType> SubscribeTypes()
        {
            return _objectsRepository.SubscribeTypes();
        }

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
