using Ascon.Pilot.SDK;
using DynamoPilot.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DynamoPilot.Data.Wrappers
{
    public class PFile : IWrapper
    {
        private readonly IFile _file;
        public PFile(IFile file)
        {
            _file = file;
        }

        public override string ToString()
        {
            return $"{_file.Name} ({_file.Id})";
        }

        public Guid Id => _file.Id;

        public long Size => _file.Size;

        public string Md5 => _file.Md5;

        public string Name => _file.Name;

        public DateTime Modified => _file.Modified;

        public DateTime Created => _file.Created;

        public DateTime Accessed => _file.Accessed;

        //public ReadOnlyCollection<ISignature> Signatures => _file.;

        public IReadOnlyCollection<PSignatureRequest> SignatureRequests
            => new ReadOnlyCollection<PSignatureRequest>(_file.SignatureRequests.Select(i => new PSignatureRequest(i)).ToList());

        public object Unwrap()
        {
            return _file;
        }
    }
}
