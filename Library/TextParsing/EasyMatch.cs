using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace WeatherMachine.Library.TextParsing
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
            return int.Parse(Single(name));
        }

        public IEnumerable<int> AllInt(string name)
        {
            return _matches.Groups[name]
                .Captures
                .Select(c => int.Parse(c.Value));
        }

        public long SingleLong(string name)
        {
            return long.Parse(Single(name));
        }

        public IEnumerable<long> AllLong(string name)
        {
            return _matches.Groups[name]
                .Captures
                .Select(c => long.Parse(c.Value));
        }

        public string Single(string name)
        {
            var group = _matches.Groups[name];

            if (group.Captures.Count == 0)
                throw new InvalidOperationException($"{name} can't be found in '{_text}'");

            if (group.Captures.Count > 1)
                throw new InvalidOperationException($"{name} is ontains multiple times in '{_text}': Use method {nameof(AllInt)} instead");

            return group.Value;
        }

        internal IEnumerable<(long start, long length)> AllRange(string name)
        {
            return _matches.Groups[name]
                .Captures
                .Select(c => 
                (long.Parse(c.Value.Split(" ")[0]),
                long.Parse(c.Value.Split(" ")[1])));
        }
    }
}
