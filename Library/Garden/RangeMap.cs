using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMachine.Library.Garden
{
    internal class RangeMap : Map
    {
        private Identifier fromStart;
        private Identifier toStart;
        private long length;
        private Map defaultMapping;

        public RangeMap(Identifier fromStart, Identifier toStart, long length, Map defaultMapping)
        {
            this.fromStart = fromStart;
            this.toStart = toStart;
            this.length = length;
            this.defaultMapping = defaultMapping;
        }

        public string Origin => fromStart.Type;

        public string Destination => toStart.Type;

        public Identifier From(Identifier number)
        {
            if (fromStart <= number && number < fromStart + length)
            {
                return new Identifier(Destination, number - fromStart + toStart);
            }

            return defaultMapping.From(number);
        }
    }
}
