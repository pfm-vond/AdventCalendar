using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMachine.Library.Trebuchet
{
    public class Builder
    {
        public static CalibrationDocument FromText(string calibrations)
        {
            var lines = calibrations.Split(Environment.NewLine);
            DigitParser digitParser = new TextDigitParser();
            return new CalibrationValueCollection(
                lines.Select(l => 
                new TwoDigitCalibrationValue(
                    new CalibrationLine(digitParser.Parse(l))))
                );
        }
    }
}
