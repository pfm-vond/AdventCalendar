using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMachine.Library.CubeConundrum
{
    public record Record(uint Id, CubeSet[] Hands)
    {
        public bool CouldHaveBeenTakenFrom(CubeSet bag)
        {
            return Hands.All(h => h.CouldHaveBeenTakenFrom(bag));
        }

        public CubeSet MinimalBag()
        {
            Dictionary<string, int> bag = new();

            foreach (CubeSet hand in Hands) 
            {
                foreach (string color in hand)
                {
                    if (hand[color] > bag.GetValueOrDefault(color, 0))
                    {
                        bag[color] = hand[color];
                    }
                }

            }

            return new CubeSet(bag);
        }
    }
}
