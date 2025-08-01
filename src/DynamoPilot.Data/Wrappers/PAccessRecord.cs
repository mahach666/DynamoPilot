using Ascon.Pilot.SDK;
using DynamoPilot.Data.Contracts;
using System;

namespace DynamoPilot.Data.Wrappers
{
    public class PAccessRecord : IWrapper
    {
        private readonly IAccessRecord _accessRecord;
        public PAccessRecord(IAccessRecord accessRecord)
        {
            _accessRecord = accessRecord;
        }
        public override string ToString()
        {
            return $"{_accessRecord.Access} ({_accessRecord.OrgUnitId})";
        }

        public int OrgUnitId => _accessRecord.OrgUnitId;

        public PAccess Access => new(_accessRecord.Access);

        public int RecordOwner => _accessRecord.RecordOwner;

        public Guid InheritanceSource => _accessRecord.InheritanceSource;

        public object Unwrap()
        {
            return _accessRecord;
        }
    }
}
