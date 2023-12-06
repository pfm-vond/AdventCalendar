using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMachine.Library.CubeConundrum
{
    public class PlaythroughBuilder
    {
        public static Playthrough FromText(string playthrough)
        {
            return new Playthrough(playthrough
                .Split(Environment.NewLine)
                .Select(RecordBuilder.FromText)
                .ToArray());
        }
    }
}
