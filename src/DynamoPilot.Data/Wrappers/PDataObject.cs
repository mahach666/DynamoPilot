using Ascon.Pilot.SDK;
using DynamoPilot.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DynamoPilot.Data.Wrappers
{
    public class PDataObject : IWrapper
    {
        private readonly IDataObject _dataObject;
        public PDataObject(IDataObject dataObject)
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

        public PType Type => new(_dataObject.Type);

        public PPerson Creator => new(_dataObject.Creator);

        public ReadOnlyCollection<Guid> Children => _dataObject.Children;

        public ReadOnlyCollection<PRelation> Relations
            => new ReadOnlyCollection<PRelation>(_dataObject.Relations.Select(i => new PRelation(i)).ToList());

        public ReadOnlyCollection<Guid> RelatedSourceFiles => _dataObject.RelatedSourceFiles;

        //public ReadOnlyCollection<Guid> RelatedTaskInitiatorAttachments => _dataObject.RelatedTaskInitiatorAttachments;

        //public ReadOnlyCollection<Guid> RelatedTaskExecutorAttachments => _dataObject.RelatedTaskExecutorAttachments;

        //public ReadOnlyCollection<Guid> RelatedTaskMessageAttachments => _dataObject.RelatedTaskMessageAttachments;

        public IDictionary<Guid, int> TypesByChildren => _dataObject.TypesByChildren;

        public DataState State => _dataObject.State;

        public PStateInfo ObjectStateInfo => new(_dataObject.ObjectStateInfo);

        public SynchronizationState SynchronizationState => _dataObject.SynchronizationState;

        public ReadOnlyCollection<PFile> Files
            => new ReadOnlyCollection<PFile>(_dataObject.Files.Select(i => new PFile(i)).ToList());

        //public IDictionary<int, IAccess> Access => _dataObject.Access;

        public ReadOnlyCollection<PAccessRecord> Access2
            => new ReadOnlyCollection<PAccessRecord>(_dataObject.Access2.Select(i => new PAccessRecord(i)).ToList());

        public bool IsSecret => _dataObject.IsSecret;

        //public bool IsDeleted => _dataObject.IsDeleted;

        //public bool IsInRecycleBin => _dataObject.IsInRecycleBin;

        public PFilesSnapshot ActualFileSnapshot => new(_dataObject.ActualFileSnapshot);

        public ReadOnlyCollection<PFilesSnapshot> PreviousFileSnapshots 
            => new ReadOnlyCollection<PFilesSnapshot>(_dataObject.PreviousFileSnapshots.Select(i => new PFilesSnapshot(i)).ToList());

        public ReadOnlyCollection<int> Subscribers => _dataObject.Subscribers;

        public ReadOnlyCollection<Guid> Context()
            => new ReadOnlyCollection<Guid>(_dataObject.Context());

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
