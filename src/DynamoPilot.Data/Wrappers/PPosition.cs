using Ascon.Pilot.SDK;
using DynamoPilot.Data.Contracts;

namespace DynamoPilot.Data.Wrappers
{
    public class PPosition : IPosition, IWrapper
    {
        private readonly IPosition _position;
        public PPosition(IPosition position)
        {
            _position = position;
        }

        public override string ToString()
        {
            return $"{_position.Position}";
        }

        public int Order => _position.Order;

        public int Position => _position.Position;

        public object Unwrap()
        {
            return _position;
        }
    }
}
