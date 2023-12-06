using System.Linq;

namespace calibration
{
    public class UnexpectedSpecificationAddition
    {
        [Fact]
        public void oneight_is_eight_even_if_e_is_part_of_both_one_and_eight()
        {
            Trebuchet.CalibrationDocument onelineCalibration = Trebuchet.Builder
                .FromText("126dzbvg6two4oneightntd");

            onelineCalibration.Single().Value.Should().Be(18);
        }
    }
}
