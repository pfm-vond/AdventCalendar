using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMachine.Library.CubeConundrum
{
    public class Playthrough
    {
        private Record[] records;

        public Playthrough(Record[] records)
        {
            this.records = records;
        }

        public IEnumerable<Record> GameFromThisBag(CubeSet bag)
        {
            foreach (var record in records)
            {
                if(record.CouldHaveBeenTakenFrom(bag))
                    yield return record;
            }
        }

        public int MinimalPower()
        {
            int sum = 0;

            foreach (var record in records)
            {
                sum += record.MinimalBag().Power();
            }

            return sum;
        }

        public uint SumGameIdFromThisBag(CubeSet bag)
        {
            uint sum = 0;

            foreach (var record in GameFromThisBag(bag)) 
            {
                sum += record.Id;
            }

            return sum;
        }
    }
}
