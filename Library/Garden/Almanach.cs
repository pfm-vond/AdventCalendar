using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMachine.Library.Garden
{
    public class Almanach
    {
        public Almanach(ImmutableArray<Identifier> seeds, Map seedToLocationMap)
        {
            Seeds = seeds;
            SeedToLocationMap = seedToLocationMap;
        }

        public ImmutableArray<Identifier> Seeds { get; }
        private readonly Map SeedToLocationMap;

        private IEnumerable<Identifier> Locations => Seeds.Select(SeedToLocationMap.From);

        public Identifier SmallestLocation()
        {
            return Locations.Min();
        }
    }
}
