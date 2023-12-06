using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMachine.Library.Trebuchet
{
    internal class CalibrationLine
    {
        public CalibrationLine(int[] digits)
        {
            FirstDigit  = digits.First();
            LastDigit = digits.Last();
        }

        public int FirstDigit { get; init; }
        public int LastDigit { get; init; }
    }
}
