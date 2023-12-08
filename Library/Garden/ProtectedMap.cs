using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMachine.Library.Garden
{
    internal class ProtectedMap : Map
    {
        private readonly Map map;

        public ProtectedMap(Map map)
        {
            this.map = map;
        }

        public string Origin => map.Origin;

        public string Destination => map.Destination;

        public Identifier From(Identifier id)
        {

            if (id.Type != Origin)
            {
                throw new ArgumentException(id.Type + "should Be Of type" + Origin);
            }

            return map.From(id);
        }
    }
}
