using Ascon.Pilot.SDK;
using DynamoPilot.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DynamoPilot.Data.Wrappers
{
    public class PilotDataObject : IWrapper
    {
        private readonly IDataObject _dataObject;
        public PilotDataObject(IDataObject dataObject)
        {
            _dataObject = dataObject;
        }

        public override string ToString()
        {
            return $"{_dataObject.DisplayName} ({_dataObject.Id})";
        }

        public Guid Id => _dataObject.Id;

        public Guid ParentId => _dataObject.ParentId;

        public DateTime Created => _dataObject.Created;

        public IDictionary<string, object> Attributes => _dataObject.Attributes;

        public string DisplayName => _dataObject.DisplayName;

        public PilotType Type => new(_dataObject.Type);

        public PilotPerson Creator => new(_dataObject.Creator);

        public ReadOnlyCollection<Guid> Children => _dataObject.Children;

        public ReadOnlyCollection<IRelation> Relations => _dataObject.Relations;

        public ReadOnlyCollection<Guid> RelatedSourceFiles => _dataObject.RelatedSourceFiles;

        //public ReadOnlyCollection<Guid> RelatedTaskInitiatorAttachments => _dataObject.RelatedTaskInitiatorAttachments;

        //public ReadOnlyCollection<Guid> RelatedTaskExecutorAttachments => _dataObject.RelatedTaskExecutorAttachments;

        //public ReadOnlyCollection<Guid> RelatedTaskMessageAttachments => _dataObject.RelatedTaskMessageAttachments;

        public IDictionary<Guid, int> TypesByChildren => _dataObject.TypesByChildren;

        public DataState State => _dataObject.State;

        public IStateInfo ObjectStateInfo => _dataObject.ObjectStateInfo;

        public SynchronizationState SynchronizationState => _dataObject.SynchronizationState;

        public ReadOnlyCollection<IFile> Files => _dataObject.Files;

        //public IDictionary<int, IAccess> Access => _dataObject.Access;

        public ReadOnlyCollection<IAccessRecord> Access2 => _dataObject.Access2;

        public bool IsSecret => _dataObject.IsSecret;

        //public bool IsDeleted => _dataObject.IsDeleted;

        //public bool IsInRecycleBin => _dataObject.IsInRecycleBin;

        public IFilesSnapshot ActualFileSnapshot => _dataObject.ActualFileSnapshot;

        public ReadOnlyCollection<IFilesSnapshot> PreviousFileSnapshots => _dataObject.PreviousFileSnapshots;

        public ReadOnlyCollection<int> Subscribers => _dataObject.Subscribers;

        //public ILockInfo LockInfo => _dataObject.LockInfo;

        //public ITaskObject ToTaskObject()
        //{
        //  return  _dataObject.ToTaskObject();
        //}

        public object Unwrap()
        {
            return _dataObject;
        }
    }
}
