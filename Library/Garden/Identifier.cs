using System;

namespace WeatherMachine.Library.Garden
{
    public record Identifier(string Type, long Value) : IComparable
    {
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            if (obj.GetType() != typeof(Identifier)) return 1;
            Identifier other = (Identifier)obj;
            if(other.Type != this.Type) return 1;
            return Value.CompareTo(other.Value);
        }

        public static implicit operator long(Identifier id)
        {
            return id.Value;
        }

        public static implicit operator Identifier(int id)
        {
            return new Identifier("unknown", id);
        }
    }
}
