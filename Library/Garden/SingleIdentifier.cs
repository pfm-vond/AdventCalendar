namespace WeatherMachine.Library.Garden
{
    public record SingleIdentifier(string Type, long Value) : Identifier
    {
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            if (!obj.GetType().IsAssignableTo(typeof(Identifier))) return 1;
            Identifier other = (Identifier)obj;
            if (other.Type != this.Type) return 1;
            return Value.CompareTo(other.Value);
        }

        public static implicit operator long(SingleIdentifier id)
        {
            return id.Value;
        }

        public static implicit operator SingleIdentifier(int id)
        {
            return new SingleIdentifier("unknown", id);
        }
    }
}
