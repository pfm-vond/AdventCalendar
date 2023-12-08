using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WeatherMachine.Library.TextParsing;

namespace WeatherMachine.Library.Scratchcards
{
    public class Builder
    {
        private int id;
        private HashSet<int> winningNumbers;
        private HashSet<int> playedNumbers;

        public Builder()
        {
        }

        public Builder FromText(string text)
        {
            var parseLine =  new Regex("^Card +(?<id>\\d+): +(?>(?<winningNumber>\\d+) +)+\\|(?> +(?<playedNumbers>\\d+))+");
            var values = new EasyMatch(parseLine, text);

            this.id = values.SingleInt("id");
            this.winningNumbers = values.AllInt("winningNumber").ToHashSet();
            this.playedNumbers = values.AllInt("playedNumbers").ToHashSet();

            return this;
        }

        public Card Build()
        {
            return new Card(
                id,
                winningNumbers.ToImmutableHashSet(),
                playedNumbers.ToImmutableHashSet());
        }
    }
}
