using Ascon.Pilot.SDK;
using DynamoPilot.Data.Contracts;
using System;

namespace DynamoPilot.Data.Wrappers
{
    public class PAccess : IWrapper
    {
        private readonly IAccess _access;
        public PAccess(IAccess access)
        {
            _access = access;
        }
        public override string ToString()
        {
            return $"{_access.AccessLevel} ({_access.Type})";
        }

        public AccessLevel AccessLevel => _access.AccessLevel;

        public DateTime ValidThrough => _access.ValidThrough;

        public bool IsInheritable => _access.IsInheritable;

        public AccessInheritance Inheritance => _access.Inheritance;

        public bool IsInherited => _access.IsInherited;

        public AccessType Type => _access.Type;

        public int[] TypeIds => _access.TypeIds;

        public object Unwrap()
        {
            return _access;
        }
    }
}
