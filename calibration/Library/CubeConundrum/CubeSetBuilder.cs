using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMachine.Library.CubeConundrum
{
    public class CubeSetBuilder
    {
        public static CubeSet FromText(string cubeSet)
        {
            Dictionary<string, int> structuredCubeSet = new();

            foreach (string cube in cubeSet.Split(","))
            {
                var color = cube.Trim().Split(' ');
                structuredCubeSet.Add(color[1], int.Parse(color[0]));
            }

            return new CubeSet(structuredCubeSet);
        }
    }
}
