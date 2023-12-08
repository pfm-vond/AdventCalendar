using System;

namespace WeatherMachine.Library.Garden
{
    internal class ComposedMap : Map
    {
        private readonly Map _originToTemp;
        private readonly Map _tempToDestination;

        public ComposedMap(Map originToTemp, Map tempToDestination)
        {
            _originToTemp = originToTemp;
            _tempToDestination = tempToDestination;
            Origin = originToTemp.Origin;
            Destination = tempToDestination.Destination;
        }

        public string Origin { get; private init; }

        public string Destination { get; private init; }

        public Identifier From(Identifier id)
        {
            return _tempToDestination.From(_originToTemp.From(id));
        }
    }
}
