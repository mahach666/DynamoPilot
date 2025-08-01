using Ascon.Pilot.SDK;
using DynamoPilot.Data.Contracts;
using System.Collections.ObjectModel;

namespace DynamoPilot.Data.Wrappers
{
    public class POrganisationUnit : IWrapper
    {
        private readonly IOrganisationUnit _organisationUnit;
        public POrganisationUnit(IOrganisationUnit organisationUnit)
        {
            _organisationUnit = organisationUnit;
        }

        public override string ToString()
        {
            return $"{_organisationUnit.Title} ({_organisationUnit.Id})";
        }

        public int Id => _organisationUnit.Id;

        public string Title => _organisationUnit.Title;

        public bool IsDeleted => _organisationUnit.IsDeleted;

        public ReadOnlyCollection<int> Children => _organisationUnit.Children;

        public bool IsPosition => _organisationUnit.IsPosition;

        public bool IsChief => _organisationUnit.IsChief;

        public object Unwrap()
        {
            return _organisationUnit;
        }
    }
}
