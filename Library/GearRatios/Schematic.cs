using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMachine.Library.GearRatios
{
    public class Schematic
    {
        private SchematicElement[,] elements;

        public Schematic(int width, int height)
        {
            elements = new SchematicElement[width, height];
            Parts = new HashSet<SchematicElement>();
            Gears = new List<Gear>();
        }

        public int Width => elements.GetLength(1);

        public int Height => elements.GetLength(0);

        private HashSet<SchematicElement> Parts;

        public List<int> PartNumbers => Parts.Select(p => p.Value).ToList();

        public int SolutionNumber => PartNumbers.Sum();
        public int GearRatio => Gears.Sum(g => g.Ratio);

        public List<Gear> Gears;

        public void Add(int partNumber, int line, int pos)
        {
            SchematicElement part = new SchematicElement(partNumber, line, pos);
            for (int i = 0; i < partNumber.ToString().Length; i++)
            {
                elements[line, pos + i] = part;
            }
        }

        public void ConsiderGearCandidate(int line, int pos)
        {
            var neibouringPart = Parts.Where(p => p.IsNextTo(line, pos)).ToList();
            if (neibouringPart.Count() == 2)
            {
                Gears.Add(new Gear(neibouringPart[0], neibouringPart[1]));
            }
        }

        public void SetAdjacentElementToPart(int line, int pos)
        {
            for (int neigbouringLine = line - 1; neigbouringLine <= line + 1; neigbouringLine++)
                for (int neibouringPos = pos - 1; neibouringPos <= pos + 1; neibouringPos++)
                {
                    if(HasElement(neigbouringLine, neibouringPos, out SchematicElement value))
                    {
                        Parts.Add(value);
                    }
                }
        }

        private bool HasElement(int l, int p, out SchematicElement value)
        {
            bool Fail(out SchematicElement value)
            {
                value = null;
                return false;
            }

            if (l < 0 || l >= Height) 
            {
                return Fail(out value);
            }

            if (p < 0 || p >= Width)
            {
                return Fail(out value);
            }

            var element = elements[l, p];

            if (element is null)
            {
                return Fail(out value);
            }

            value = element;
            return true;
        }
    }
}
