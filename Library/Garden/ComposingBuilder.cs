using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WeatherMachine.Library.Scratchcards;
using WeatherMachine.Library.TextParsing;

namespace WeatherMachine.Library.Garden
{
    public class ComposingBuilder
    {
        private readonly Dictionary<string, Map> maps;
        private readonly string _from;
        private readonly string _to;

        public ComposingBuilder(string from, string to)
        {
            maps = new Dictionary<string, Map>();
            _from = from;
            _to = to;
        }

        public Map Build()
        {
            var map = maps[_from];
            maps.Remove(_from);
            var current = map.Destination;

            while (current != _to)
            {
                map = new ComposedMap(map, maps[current]);
                maps.Remove(current);
                current = map.Destination;
            }

            return new ProtectedMap(map);
        }

        public ComposingBuilder FromMaps(IEnumerable<string> maps)
        {
            foreach (var map in maps)
            {
                var mapParsed = new Builder()
                    .FromText(map)
                    .Build();

                this.Using(mapParsed);
            }

            return this;
        }

        public ComposingBuilder FromText(string text)
        {
            return FromMaps(text.SplitOnEmptyLine());
        }

        public ComposingBuilder Using(Map map)
        {
            maps.Add(map.Origin, map);
            return this;
        }
    }
}
