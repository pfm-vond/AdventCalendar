using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace calibration.Day3
{
    public class FirstHalfGearRatioSpecification
    {
        [Theory]
        [InlineData(@"467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..", 10, 10)]
        [InlineData(@"467
...", 3, 2)]
        public void the_schematic_consist_in_a_grid_of_part(string text, int width, int height)
        {
            GearRatios.Schematic engine = GearRatios.SchematicBuilder.FromText(text);

            engine.Width.Should().Be(width);
            engine.Height.Should().Be(height);
        }

        [Fact]
        public void any_number_adjacent_to_a_symbol_even_diagonally_is_a_partMumber()
        {
            GearRatios.Schematic engine = new GearRatios.Schematic(10, 10);

            engine.Add(467, 0, 0);
            engine.SetAdjacentToPartNumber(1, 3);

            engine.PartNumbers.Should().Contain(467);
        }

        [Fact]
        public void Schematic_can_be_retrieved_from_text_representation()
        {
            GearRatios.Schematic engine = GearRatios.SchematicBuilder.FromText(@"467.
...*");

            engine.PartNumbers.Should().Contain(467);
        }

        [Fact]
        public void Schematic_solution_number_is_the_sum_of_all_partNumber()
        {
            GearRatios.Schematic engine = GearRatios.SchematicBuilder.FromText(@"467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.617..");

            engine.SolutionNumber.Should().Be(4380);
        }
    }
}
