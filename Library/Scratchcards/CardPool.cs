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

        public int Score()
        {
            return Cards.Sum(c => c.Score());
        }
    }
}
