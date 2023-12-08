using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using WeatherMachine.Library.Garden.Extentions;
using WeatherMachine.Library.TextParsing;

namespace WeatherMachine.Library.Garden
{
    public class AlmanachBuilder
    {
        private readonly List<Identifier> _seeds = new();
        private Map seedToLocationMap;

        public Almanach Build()
        {
            return new Almanach(_seeds.ToImmutableArray(), seedToLocationMap);
        }

        public AlmanachBuilder FromText(string text)
        {
            string[] blocs = text.SplitOnEmptyLine();

            _seeds.AddRange(ParseSeeds(blocs[0]));

            seedToLocationMap = new ComposingBuilder("seed", "location")
                .FromMaps(blocs.Skip(1))
                .Build();

            return this;
        }

        private IEnumerable<Identifier> ParseSeeds(string seeds)
        {
            var seedFormat = new Regex("^seeds:(?> +(?<seeds>\\d+))+");
            var values = new EasyMatch(seedFormat, seeds);

            return values.AllLong("seeds").Select(id => id.Seed());
        }
    }
}
