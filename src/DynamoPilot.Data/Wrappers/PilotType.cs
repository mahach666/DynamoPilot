using Ascon.Pilot.SDK;
using DynamoPilot.Data.Contracts;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DynamoPilot.Data.Wrappers
{
    public class PilotType : IWrapper
    {
        private readonly IType _type;
        public PilotType(IType refer)
        {
            _type = refer;
        }

        public override string ToString()
        {
            return $"{_type.Title} - {_type.Name}";
        }

        //public int Id => _type.Id;
        public int Id => _type.Id;

        public string Name => _type.Name;

        public string Title => _type.Title;

        public int Sort => _type.Sort;

        public bool HasFiles => _type.HasFiles;

        public ReadOnlyCollection<int> Children => _type.Children;

        public ReadOnlyCollection<PilotAttribute> Attributes
            => new ReadOnlyCollection<PilotAttribute>(_type.Attributes.Select(a => new PilotAttribute(a)).ToList());

        public IEnumerable<PilotAttribute> DisplayAttributes
            => _type.DisplayAttributes.Select(a => new PilotAttribute(a));

        public byte[] SvgIcon => _type.SvgIcon;

        public bool IsMountable => _type.IsMountable;

        public TypeKind Kind => _type.Kind;

        public bool IsDeleted => _type.IsDeleted;

        public bool IsService => _type.IsService;

        public bool IsProject => _type.IsProject;

        public object Unwrap()
        {
            return _type;
        }
    }
}
