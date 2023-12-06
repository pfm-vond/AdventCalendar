using System.Linq;

namespace calibrations
{
    public class SecondHalfCalibrationSpecification
    {
        [Theory]
        [InlineData("one2one", 11)]
        [InlineData("two1nine", 29)]
        public void some_of_the_digits_are_actually_spelled_out_with_letters(string line, int value)
        {
            Trebuchet.CalibrationDocument onelineCalibration = Trebuchet.Builder.FromText(line);
            onelineCalibration.Single().Value.Should().Be(value);
        }

        [Fact]
        public void each_line_contain_a_specific_calibration_value_need_to_be_recover()
        {
            Trebuchet.CalibrationDocument givenExemple = Trebuchet.Builder.FromText(@"two1nine
eightwothree
abcone2threexyz
xtwone3four
4nineeightseven2
zoneight234
7pqrstsixteen");
            givenExemple.ToString().Should().Be("29,83,13,24,42,14,76");
            givenExemple.Sum().Should().Be(281);
        }
    }
}
