using FluentAssertions;
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
    public class SecondHalfGearRatioSpecification
    {
        [Theory]
        [InlineData(@"467
...", 0)]
        [InlineData(@"4..
.*5", 1)]
        [InlineData(@"..4
5*.", 1)]
        [InlineData(@"467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..", 2)]
        public void A_gear_is_any_star_symbol_that_is_adjacent_to_exactly_two_part_numbers(string text, int GearNumber)
        {
            GearRatios.Schematic engine = GearRatios.SchematicBuilder.FromText(text);

            engine.Gears.Should().HaveCount(GearNumber);
        }

        [Fact]
        public void The_gear_ratio_of_a_gear_is_the_product_of_the_neigbouring_parts()
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
.664.598..");

            engine.Gears.Select(g => g.Ratio)
                .Should()
                .BeEquivalentTo(new int[] { 16345 , 451490 });
        }

        [Fact]
        public void The_gear_ratio_of_the_engine_is_the_sum_of_all_its_gear()
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
.664.598..");

            engine.GearRatio
                .Should()
                .Be(467835);
        }
    }
}
