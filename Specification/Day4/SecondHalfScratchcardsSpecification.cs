using Xunit;
namespace calibration.Day4
{
    public class SecondHalfScratchcardsSpecification
    {
        [Fact]
        public void Cardpool_keeps_a_quantity_associated_with_each_card()
        {
            Scratchcards.CardPool pool = new Scratchcards.PoolBuilder(new Scratchcards.Builder())
                .FromText(@"Card 5: 88 83 26 28 32 | 87 30 70 12 93 22 82 36
Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11")
                .Build();

            pool.CardQuantities().Should().BeEquivalentTo(new int[] { 1 /* card5 */ , 1 /* card6 */ });
        }

        [Fact]
        public void ScratchCard_make_you_win_card_depending_on_the_number_of_played_winning_number()
        {
            Scratchcards.CardPool pool = new Scratchcards.PoolBuilder(new Scratchcards.Builder())
                .FromText(@"Card 5: 88 83 26 28 32 | 88 30 70 12 93 22 82 36
Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11")
                .Build();

            pool.CardQuantities().Should().BeEquivalentTo(new int[] { 1 /* card5 */ , 2 /* card6 */ });
        }

        [Fact]
        public void ScratchCardPool_score_is_the_final_number_of_ScratchCard()
        {
            Scratchcards.CardPool pool = new Scratchcards.PoolBuilder(new Scratchcards.Builder())
                .FromText(@"Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11")
                .Build();

            pool.Score().Should().Be(30);
        }
    }
}
