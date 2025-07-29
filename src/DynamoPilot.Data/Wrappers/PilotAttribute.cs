using Ascon.Pilot.SDK;
using DynamoPilot.Data.Contracts;

namespace DynamoPilot.Data.Wrappers
{
    public class PilotAttribute :  IWrapper
    {
        private readonly IAttribute _attribute;
        public PilotAttribute(IAttribute attribute)
        {
            _attribute = attribute ;
        }
        public string Name => _attribute.Name;

        public string Title => _attribute.Title;

        public bool IsObligatory => _attribute.IsObligatory;

        public int DisplaySortOrder => _attribute.DisplaySortOrder;

        public bool ShowInObjectsExplorer => _attribute.ShowInObjectsExplorer;

        //public bool InGroup => _attribute.InGroup;

        public bool JoinWithPrevious => _attribute.JoinWithPrevious;

        public bool IsService => _attribute.IsService;

        //public string Configuration => _attribute.Configuration;

        public int DisplayHeight => _attribute.DisplayHeight;

        public AttributeType Type => _attribute.Type;

        public string GroupTitle => _attribute.GroupTitle;

        //public bool IsUnique => _attribute.IsUnique;

        public AttributeUniquenessType UniquenessType => _attribute.UniquenessType;

        public object Unwrap()
        {
            return _attribute;
        }
    }
}
