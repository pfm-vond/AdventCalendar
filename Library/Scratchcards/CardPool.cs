using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMachine.Library.Scratchcards
{
    public record CardPool(ImmutableArray<Card> Cards)
    {
        public int Length => Cards.Length;

        public IEnumerable<int> CardQuantities()
        {
            var cardQuantities = Enumerable.Repeat(1, Cards.Length).ToArray();

            for(int index = 0; index < Cards.Length; index++)
            {
                for (int j = index + 1; j <= index + Cards[index].PlayedWiningCount(); j++)
                {
                    cardQuantities[j] += cardQuantities[index];
                }
            }

            return cardQuantities;
        }

        public int Score()
        {
            return TotalCardNumber();
        }

        public int ScoreAccordingToTheElfHypothesis()
        {
            return Cards.Sum(c => c.Score());
        }

        private int TotalCardNumber()
        {
            return CardQuantities().Sum();
        }
    }
}
