using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Reflection.Metadata;
using Xunit.Sdk;

namespace calibrations
{
    public class FirstHalfCalibrationSpecification
    {
        [Fact]
        public void The_newly_improved_calibration_document_consists_of_lines_of_text()
        {
            Trebuchet.CalibrationDocument onelineCalibration = Trebuchet.Builder.FromText("Te1x1t");
            onelineCalibration.NbLines.Should().Be(1);

            Trebuchet.CalibrationDocument twolineCalibration = Trebuchet.Builder.FromText(@"Te1x1t
Te1x2t");
            twolineCalibration.NbLines.Should().Be(2);

            Trebuchet.CalibrationDocument multiplelineCalibration = Trebuchet.Builder.FromText(@"Te1x1t
Te1x2t
Te1x2t
Te1x2t
Te1x2t");
            multiplelineCalibration.NbLines.Should().Be(5);
        }

        [Theory]
        [InlineData("Te1x1t", 11)]
        [InlineData("Te1x2t", 12)]
        [InlineData("Te2x2t", 22)]
        [InlineData("Te2xt", 22)]
        public void a_line_contain_a_specific_calibration_value_need_to_be_recover(string line, int value)
        {
            Trebuchet.CalibrationDocument onelineCalibration = Trebuchet.Builder.FromText(line);
            onelineCalibration.Single().Value.Should().Be(value);
        }

        [Fact]
        public void each_line_contain_a_specific_calibration_value_need_to_be_recover()
        {
            Trebuchet.CalibrationDocument givenExemple = Trebuchet.Builder.FromText(@"1abc2
pqr3stu8vwx
a1b2c3d4e5f
treb7uchet");
            givenExemple.ToString().Should().Be("12,38,15,77");
        }

        [Fact]
        public void Consider_an_entire_calibration_document_all_calibration_values_can_be_sum()
        {
            Trebuchet.CalibrationDocument givenExemple = Trebuchet.Builder.FromText(@"1abc2
pqr3stu8vwx
a1b2c3d4e5f
treb7uchet");

            givenExemple.Sum().Should().Be(142);
        }
    }
}
