using System;

namespace WeatherMachine.Library.Garden
{
    public interface Identifier : IComparable
    {
        public string Type { get; }

        public long Value { get; }
    }
}
