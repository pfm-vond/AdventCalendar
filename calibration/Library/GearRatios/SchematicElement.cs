using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMachine.Library.GearRatios
{
    public record SchematicElement(int Value, int line, int startPos)
    {
        internal bool IsNextTo(int refline, int refPos)
        {
            if(Math.Abs(refline - line) > 1)
                return false;

            for(int pos = startPos; pos < startPos + Value.ToString().Length; pos++)
                if (Math.Abs(refPos - pos) <= 1)
                    return true;

            return false;
        }
    }
}
