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
    public class FirstHalfGameSpecification
    {
        [Theory]
        [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 1)]
        [InlineData("Game 2: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 2)]
        public void Each_game_is_listed_with_its_ID_number(string text, uint id)
        {
            CubeConundrum.Record record = CubeConundrum.RecordBuilder.FromText(text);

            record.Id.Should().Be(id);
        }

        [Theory]
        [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 3)]
        [InlineData("Game 2: 3 blue, 4 red", 1)]
        public void followed_by_a_semicolon_separated_list_of_subsets(string text, int nbHand)
        {
            CubeConundrum.Record record = CubeConundrum.RecordBuilder.FromText(text);

            record.Hands.Length.Should().Be(nbHand);
        }

        [Fact]
        public void of_cubes_that_were_revealed_from_the_bag()
        {
            CubeConundrum.Record record = CubeConundrum.RecordBuilder.FromText(
                "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green");

            record.Hands.First()["blue"].Should().Be(3);
            record.Hands.First()["red"].Should().Be(4);
            record.Hands.Last()["blue"].Should().Be(0);
        }



        [Theory]
        [InlineData("12 red, 13 green, 14 blue", true)]
        [InlineData("12 red, 13 green, 1 blue", false)]
        public void A_Game_Is_possible_if_bag_contains_more_than_in_hand(string bagContent, bool canBeTheOriginalBag)
        {
            CubeConundrum.Record record = CubeConundrum.RecordBuilder.FromText(
                "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green");

            CubeConundrum.CubeSet bag = CubeConundrum.CubeSetBuilder.FromText(
                bagContent);

            record.CouldHaveBeenTakenFrom(bag).Should().Be(canBeTheOriginalBag);
        }

        [Fact]
        public void A_playthrought_is_a_list_of_record_separated_by_newline()
        {
            CubeConundrum.Playthrough records = CubeConundrum.PlaythroughBuilder.FromText(
                @"Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green");

            CubeConundrum.CubeSet bag = CubeConundrum.CubeSetBuilder.FromText(
                "12 red, 13 green, 14 blue");

            records.GameFromThisBag(bag)
                .Select(g => g.Id)
                .Should()
                .BeEquivalentTo(new uint[] { 1,2,5 });
        }

        [Fact]
        public void A_playthrought_is_summable()
        {
            CubeConundrum.Playthrough records = CubeConundrum.PlaythroughBuilder.FromText(
                @"Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green");

            CubeConundrum.CubeSet bag = CubeConundrum.CubeSetBuilder.FromText(
                "12 red, 13 green, 14 blue");

            records.SumGameIdFromThisBag(bag)
                .Should()
                .Be(8);
        }
    }
}

