using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMachine.Library.CubeConundrum
{
    public class RecordBuilder
    {
        public static Record FromText(string text)
        {
            string[] game = text.Split(':');
            return new Record(uint.Parse(
                game[0]["Game ".Length..]),
                game[1]
                .Split(';')
                .Select(CubeSetBuilder.FromText)
                .ToArray());
        }
    }
}
