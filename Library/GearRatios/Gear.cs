using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMachine.Library.GearRatios
{
    public record Gear(SchematicElement part1, SchematicElement part2)
    {
        public int Ratio => part1.Value * part2.Value;
    }
}
