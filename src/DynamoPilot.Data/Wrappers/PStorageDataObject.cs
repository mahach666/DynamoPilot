using Ascon.Pilot.SDK;
using DynamoPilot.Data.Contracts;

namespace DynamoPilot.Data.Wrappers
{
    public class PStorageDataObject : IWrapper
    {
        private readonly IStorageDataObject _storageDataObject;
        public PStorageDataObject(IStorageDataObject storageDataObject)
        {
            _storageDataObject = storageDataObject;
        }

        public override string ToString()
        {
            return $"{_storageDataObject.Path} ({_storageDataObject.State})";
        }

        public PDataObject DataObject => new(_storageDataObject.DataObject);

        public string Path => _storageDataObject.Path;

        public StorageObjectState State => _storageDataObject.State;

        public bool IsDirectory => _storageDataObject.IsDirectory;

        public object Unwrap()
        {
            return _storageDataObject;
        }
    }
}
