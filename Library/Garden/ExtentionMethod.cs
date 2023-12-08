﻿namespace WeatherMachine.Library.Garden.Extentions
{
    public static class ExtentionMethod
    {
        public static Identifier Seed(this int value)
        {
            return ((long)value).Seed();
        }

        public static Identifier Seed(this long value)
        {
            return new Identifier("seed", value);
        }

        public static Identifier Soil(this int value)
        {
            return ((long)value).Soil();
        }

        public static Identifier Soil(this long value)
        {
            return new Identifier("soil", value);
        }

        public static Identifier Fertilizer(this int value)
        {
            return ((long)value).Fertilizer();
        }

        public static Identifier Fertilizer(this long value)
        {
            return new Identifier("fertilizer", value);
        }

        public static Identifier Location(this int value)
        {
            return ((long)value).Location();
        }

        public static Identifier Location(this long value)
        {
            return new Identifier("location", value);
        }
    }
}
