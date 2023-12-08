using System.Linq;
using WeatherMachine.Library.TextParsing;

namespace WeatherMachine.Library.Trebuchet
{
    public class Builder
    {
        public static CalibrationDocument FromText(string calibrations)
        {
            var lines = calibrations.SplitLine();
            DigitParser digitParser = new TextDigitParser();
            return new CalibrationValueCollection(
                lines.Select(l => 
                new TwoDigitCalibrationValue(
                    new CalibrationLine(digitParser.Parse(l))))
                );
        }
    }
}
