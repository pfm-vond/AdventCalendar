using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMachine.Library.TextParsing;

namespace WeatherMachine.Library.Scratchcards
{
    public class PoolBuilder
    {
        private readonly Builder cardBuilder;
        List<Card> pool;

        public PoolBuilder(Builder cardBuilder)
        {
            pool = new List<Card>();
            this.cardBuilder = cardBuilder;
        }

        public PoolBuilder FromText(string cardPool)
        {
            foreach (var line in cardPool.SplitLine())
            {
                pool.Add(cardBuilder.FromText(line).Build());
            }

            return this;
        }

        public CardPool Build()
        {
            return new CardPool(pool.ToImmutableArray());
        }
    }
}
