using Ascon.Pilot.SDK;
using DynamoPilot.Data.Contracts;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace DynamoPilot.Data.Wrappers
{
    public class PPerson : IWrapper
    {
        private readonly IPerson _person;
        public PPerson(IPerson person)
        {
            _person = person;
        }

        public override string ToString()
        {
            return $"{_person.DisplayName} ({_person.Id})";
        }

        public int Id => _person.Id;

        public string Login => _person.Login;

        public string DisplayName => _person.DisplayName;

        public ReadOnlyCollection<PPosition> Positions
            => new ReadOnlyCollection<PPosition>(_person.Positions.Select(i => new PPosition(i)).ToList());

        public PPosition MainPosition => new(_person.MainPosition);

        public string Comment => _person.Comment;

        public string ServiceInfo => _person.ServiceInfo;

        public string Sid => _person.Sid;

        public bool IsDeleted => _person.IsDeleted;

        public bool IsAdmin => _person.IsAdmin;

        public string ActualName => _person.ActualName;

        public DateTime CreatedUtc => _person.CreatedUtc;

        public object Unwrap()
        {
            return _person;
        }
    }
}
