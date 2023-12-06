using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMachine.Library.GearRatios
{
    public class SchematicBuilder
    {
        public static Schematic FromText(string text)
        {
            var lines = text.Split(Environment.NewLine);

            var schematic = new Schematic(lines.Length, lines[0].Length);

            StringBuilder part = new StringBuilder();
            int linePart = -1;
            int posPart = -1;
            bool ReadingApart = false;
            HashSet<(int line,int pos)> specialChar = new();
            HashSet<(int line, int pos)> gearCandidate = new();

            for (int line = 0; line < lines.Length; line++)
            {
                for (int pos = 0; pos < lines[line].Length; pos++)
                {
                    if (char.IsDigit(lines[line][pos]))
                    {
                        if (!ReadingApart)
                        {
                            linePart = line;
                            posPart = pos;
                            ReadingApart = true;
                        }

                        part.Append(lines[line][pos]);
                    }
                    else
                    {
                        if (ReadingApart)
                        {
                            ReadingApart = false;
                            int partNumber = int.Parse(part.ToString());
                            schematic.Add(partNumber, linePart, posPart);
                            part.Clear();
                        }

                        if(lines[line][pos] != '.')
                        {
                            specialChar.Add((line, pos));

                            if(lines[line][pos] == '*')
                                gearCandidate.Add((line, pos));
                        }
                    }
                }

                if (ReadingApart)
                {
                    ReadingApart = false;
                    int partNumber = int.Parse(part.ToString());
                    schematic.Add(partNumber, linePart, posPart);
                    part.Clear();
                }
            }            

            foreach (var position in specialChar)
            {
                schematic.SetAdjacentElementToPart(position.line, position.pos);
            }

            foreach (var position in gearCandidate)
            {
                schematic.ConsiderGearCandidate(position.line, position.pos);
            }

            return schematic;
        }
    }
}
