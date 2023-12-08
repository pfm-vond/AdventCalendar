using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMachine.Library.TextParsing
{
    internal static class StringExtention
    {
        public static string[] SplitOnEmptyLine(this string text)
        {
            return text.Split(Environment.NewLine + Environment.NewLine);
        }

        public static string[] SplitLine(this string text)
        {
            return text.Split(Environment.NewLine);
        }
    }
}
