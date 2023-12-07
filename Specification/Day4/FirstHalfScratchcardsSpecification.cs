using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using WeatherMachine.Library.Scratchcards;
using Xunit;
namespace calibration.Day4
{
    public class FirstHalfScratchcardsSpecification
    {
        [Theory]
        [InlineData("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", 1)]
        [InlineData("Card 21: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", 21)]
        [InlineData("Card  1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", 21)]
        public void A_Scratchcards_has_An_id(string textCard,int id)
        {
            Scratchcards.Card card = new Scratchcards.Builder()
                .FromText(textCard)
                .Build();

            card.Id.Should().Be(id);

        }

        [Fact]
        public void A_Scratchcards_has_a_list_of_winnings_numbers()
        {
            Scratchcards.Card card = new Scratchcards.Builder()
                .FromText("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53")
                .Build();

            card.IsWinningNumber(1).Should().BeFalse();
            card.IsWinningNumber(41).Should().BeTrue();
            card.IsWinningNumber(17).Should().BeTrue();

        }

        [Fact]
        public void A_Scratchcards_has_a_list_of_played_numbers()
        {
            Scratchcards.Card card = new Scratchcards.Builder()
                .FromText("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53")
                .Build();

            card.HasBeenPlayed(1).Should().BeFalse();
            card.HasBeenPlayed(83).Should().BeTrue();
            card.HasBeenPlayed(17).Should().BeTrue();
            card.HasBeenPlayed(53).Should().BeTrue();
            card.HasBeenPlayed(9).Should().BeTrue();
        }

        [Fact]
        public void A_scratchCardPool_is_a_Set_of_cards()
        {
            Scratchcards.CardPool pool = new Scratchcards.PoolBuilder(new Scratchcards.Builder())
                .FromText(@"Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11")
                .Build();

            pool.Length.Should().Be(6);
            pool.Cards.Select(c => c.Id).Should()
                .BeEquivalentTo(new int[] { 1,2,3,4,5,6 });
        }

        [Fact]
        public void A_Scratchcards_has_a_number_of_winning_that_corresponds_to_the_number_of_played_number_that_are_winning_number()
        {
            Scratchcards.Card card = new Scratchcards.Builder()
                .FromText("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53")
                .Build();

            card.PlayedWiningNumbers()
                .Should()
                .BeEquivalentTo(new int[] { 48,83,17,86 });
        }

        [Theory]
        [InlineData("Card 1: 41 48 83 86 17 | 1 2  6 31 3  9 400 53", 0)]
        [InlineData("Card 1: 41 48 83 86 17 | 41", 1)]
        [InlineData("Card 1: 41 48 83 86 17 | 1 2  6 31 83  9 400 53", 1)]
        public void The_first_match_makes_the_card_worth_one_point(string card, int score)
        {
            Scratchcards.Card sut = new Scratchcards.Builder()
                .FromText(card)
                .Build();

            sut.Score().Should().Be(score);
        }

        [Theory]
        [InlineData("Card 1: 41 48 83 86 17 | 1 2 48 31 83  9 400 53", 2)]
        [InlineData("Card 1: 41 48 83 86 17 | 1 41 48 31 83  9 400 53", 4)]
        [InlineData("Card 1: 41 48 83 86 17 | 1 41 48 31 83 86 400 53", 8)]
        [InlineData("Card 1: 41 48 83 86 17 | 1 41 48 31 83 86 17 53", 16)]
        public void Each_match_after_the_first_doubles_the_point_value_of_that_card(string card, int score)
        {
            Scratchcards.Card sut = new Scratchcards.Builder()
            .FromText(card)
            .Build();

            sut.Score().Should().Be(score);
        }

        [Fact]
        public void A_scratchCardPool_score_is_the_of_all_its_card_score()
        {
            Scratchcards.CardPool pool = new Scratchcards.PoolBuilder(new Scratchcards.Builder())
                .FromText(@"Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11")
                .Build();

            pool.Score().Should().Be(13);
        }
    }
}
