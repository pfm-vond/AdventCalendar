using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMachine.Library.Scratchcards
{
    public record Card
    {
        public int Id { get; }
        private IImmutableSet<int> WinningNumbers { get; }
        private IImmutableSet<int> PlayedNumbers { get; }

        public Card(
            int id,
            IImmutableSet<int> winningNumbers,
            IImmutableSet<int> playedNumbers)
        {
            this.Id = id;
            WinningNumbers = winningNumbers;
            PlayedNumbers = playedNumbers;
        }

        public bool IsWinningNumber(int winningCandidate)
        {
            return WinningNumbers.Contains(winningCandidate);
        }

        public bool HasBeenPlayed(int playedCandidate)
        {
            return PlayedNumbers.Contains(playedCandidate);
        }

        public IEnumerable<int> PlayedWiningNumbers()
        {
            return WinningNumbers.Intersect(PlayedNumbers);
        }

        public int Score()
        {
            if(PlayedWiningNumbers().Any())
                return 1<<(PlayedWiningCount() - 1);

            return 0;
        }

        public int PlayedWiningCount()
        {
            return PlayedWiningNumbers().Count();
        }
    }
}
