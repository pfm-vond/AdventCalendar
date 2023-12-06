using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMachine.Library.Trebuchet
{
    public interface CalibrationValue
    {
        int Value { get; }
    }

    internal class TwoDigitCalibrationValue : CalibrationValue
    {
        public TwoDigitCalibrationValue(CalibrationLine line)
        {
            Value = line.FirstDigit * 10 + line.LastDigit;
        }

        public int Value { get; init; }
    }
}
