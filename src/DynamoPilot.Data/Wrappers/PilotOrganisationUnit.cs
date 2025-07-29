using Ascon.Pilot.SDK;
using DynamoPilot.Data.Contracts;
using System;
using System.Collections.ObjectModel;

namespace DynamoPilot.Data.Wrappers
{
    public class PilotOrganisationUnit : IOrganisationUnit, IWrapper
    {
        private readonly IOrganisationUnit _organisationUnit;
        public PilotOrganisationUnit(IOrganisationUnit organisationUnit)
        {
            _organisationUnit = organisationUnit;
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
