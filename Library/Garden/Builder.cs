using System.Text.RegularExpressions;
using System.Linq;
using WeatherMachine.Library.TextParsing;

namespace WeatherMachine.Library.Garden
{
    public class Builder
    {
        private Map map;

        public Builder() : this("unknown", "unknown") { }

        public Builder(string from, string to)
        {
            map = new ToItselfMap(from, to);
        }

        public Map Build()
        {
            return new ProtectedMap(map);
        }

        public Builder RangeMap(long toStart, long fromStart, long size)
        {
            map = new RangeMap(
                new SingleIdentifier(map.Origin, fromStart),
                new SingleIdentifier(map.Destination, toStart),
                size,
                map);

            return this;
        }

        public Builder FromText(string mapText)
        {
            var lines = mapText.SplitLine();
            return FromLines(lines);
        }

        public Builder FromLines(string[] lines)
        {
            var fromToFormat = new Regex("^(?<fromType>[^ ]+)-to-(?<toType>[^ ]+) map:");
            var values = new EasyMatch(fromToFormat, lines[0]);
            map = new ToItselfMap(values.Single("fromType"), values.Single("toType"));

            var otherLineFormat = new Regex("^(?<to>\\d+) (?<from>\\d+) (?<range>\\d+)");

            foreach (var line in lines.Skip(1))
            {
                var match = new EasyMatch(otherLineFormat, line);
                RangeMap(match.SingleLong("to"), match.SingleLong("from"), match.SingleLong("range"));
            }

            return this;
        }
    }
}
