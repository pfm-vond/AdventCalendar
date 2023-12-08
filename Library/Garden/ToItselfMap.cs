using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMachine.Library.Garden
{
    internal class ToItselfMap : Map
    {
        public ToItselfMap(string from, string to)
        {
            Origin = from;
            Destination = to;
        }

        public string Origin { get; private init; }

        public string Destination { get; private init; }

        public Identifier From(Identifier id)
        {
            return new SingleIdentifier(Destination, id.Value);
        }
    }
}
