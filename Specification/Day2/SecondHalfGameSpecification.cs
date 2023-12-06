using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using WeatherMachine.Library.CubeConundrum;
using System.Diagnostics.Contracts;

namespace calibration
{
    public class SecondHalfGameSpecification
    {

        [Fact]
        public void the_minimalBag_is_the_bag_with_the_fewest_number_of_cubes_of_each_color_that_could_have_been_taken_from()
        {
            CubeConundrum.Record record = CubeConundrum.RecordBuilder.FromText(
                "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green");

            record.MinimalBag()["red"].Should().Be(4); 
            record.MinimalBag()["blue"].Should().Be(6);
            record.MinimalBag()["green"].Should().Be(2);
        }

        [Fact]
        public void The_power_of_a_set_of_cubes_is_equal_to_the_numbers_of_cubes_of_each_color_multiplied_together()
        {
            CubeConundrum.CubeSet bag = CubeConundrum.CubeSetBuilder.FromText(
                "12 red, 13 green, 14 blue");

            bag.Power().Should().Be(12*13*14);
        }

        [Fact]
        public void The_minimal_power_of_a_playthrough_is_the_sum_of_all_minimal_bag()
        {
            CubeConundrum.Playthrough records = CubeConundrum.PlaythroughBuilder.FromText(
                @"Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green");

            records.MinimalPower()
                .Should()
                .Be(2286);
        }
    }
}

