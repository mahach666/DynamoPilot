using Ascon.Pilot.SDK;
using DynamoPilot.Data.Contracts;
using System;

namespace DynamoPilot.Data.Wrappers
{
    public class PRelation : IWrapper
    {
        private readonly IRelation _relation;
        public PRelation(IRelation relation)
        {
            _relation = relation;
        }

        public override string ToString()
        {
            return $"{_relation.Name} ({_relation.Id})";
        }

        public Guid Id =>_relation.Id;

        public Guid TargetId =>_relation.TargetId;

        public ObjectRelationType Type =>_relation.Type;

        public string Name =>_relation.Name;

        public DateTime VersionId =>_relation.VersionId;

        public object Unwrap()
        {
           return _relation;
        }
    }
}
