using Microsoft.Extensions.FileSystemGlobbing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WeatherMachine.Library.Scratchcards
{
    internal class EasyMatch
    {
        public readonly Match _matches;
        private readonly string _text;

        public EasyMatch(Regex pattern, string text)
        {
            _matches = pattern.Match(text);
            _text = text;
        }

        public int SingleInt(string name)
        {
            var group = _matches.Groups[name];

            if (group.Captures.Count == 0)
                throw new InvalidOperationException($"{name} can't be found in '{_text}'");

            if (group.Captures.Count > 1)
                throw new InvalidOperationException($"{name} is ontains multiple times in '{_text}': Use method {nameof(AllInt)} instead");

            return int.Parse(group.Value);
        }

        public IEnumerable<int> AllInt(string name)
        {
            return _matches.Groups[name]
                .Captures
                .Select(c => int.Parse(c.Value));
        }
    }
}
