using Ascon.Pilot.SDK;
using DynamoPilot.Data.Contracts;
using System;
using System.IO;

namespace DynamoPilot.Data.Wrappers
{
    public class PFileProvider : IWrapper
    {
        private readonly IFileProvider _fileProvider;
        public PFileProvider(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }
        public void DeleteLocalFile(Guid fileId)
        {
            _fileProvider.DeleteLocalFile(fileId);
        }

        public bool Exists(Guid fileId)
        {
            return _fileProvider.Exists(fileId);
        }

        public long GetFileSizeOnDisk(Guid fileId)
        {
            return _fileProvider.GetFileSizeOnDisk(fileId);
        }

        public bool IsFull(Guid fileId)
        {
            return _fileProvider.IsFull(fileId);
        }

        public Stream OpenRead(IFile file)
        {
            return _fileProvider.OpenRead(file);
        }

        public object Unwrap()
        {
            return _fileProvider;
        }
    }
}
