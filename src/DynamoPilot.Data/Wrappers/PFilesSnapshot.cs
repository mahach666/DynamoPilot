using Ascon.Pilot.SDK;
using DynamoPilot.Data.Contracts;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace DynamoPilot.Data.Wrappers
{
    public class PFilesSnapshot : IWrapper
    {
        private readonly IFilesSnapshot _filesSnapshot;
        public PFilesSnapshot(IFilesSnapshot filesSnapshot)
        {
            _filesSnapshot = filesSnapshot;
        }

        public override string ToString()
        {
            return $"{_filesSnapshot.Created} - {_filesSnapshot.Reason}";
        }

        public DateTime Created => _filesSnapshot.Created;

        public int CreatorId => _filesSnapshot.CreatorId;

        public string Reason => _filesSnapshot.Reason;

        public ReadOnlyCollection<PFile> Files
            => new ReadOnlyCollection<PFile>(_filesSnapshot.Files.Select(i => new PFile(i)).ToList());

        public object Unwrap()
        {
            return _filesSnapshot;
        }
    }
}
