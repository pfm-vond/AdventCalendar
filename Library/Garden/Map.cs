using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMachine.Library.Garden
{
    public interface Map
    {
        string Origin { get; }
        string Destination { get; }

        Identifier From(Identifier id);
    }
}
