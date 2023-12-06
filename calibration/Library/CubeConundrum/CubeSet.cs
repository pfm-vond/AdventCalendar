using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMachine.Library.CubeConundrum
{
    public class CubeSet : IEnumerable<string>
    {
        private Dictionary<string, int> Cubes;

        public CubeSet(Dictionary<string, int> cubeSet)
        {
            this.Cubes = cubeSet;
        }

        public int this[string color]
        {
            get 
            {
                return Cubes.GetValueOrDefault(color, 0);
            }
        }
        public bool CouldHaveBeenTakenFrom(CubeSet bag)
        {
            return Cubes.All(c => bag[c.Key] >= c.Value);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return Cubes.Keys.GetEnumerator();
        }

        public int Power()
        {
            int power = 1;
            
            foreach (int occurence in Cubes.Values)
            {
                power *= occurence;
            }

            return power;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Cubes.Keys.GetEnumerator();
        }
    }
}
