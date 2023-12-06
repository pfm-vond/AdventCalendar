using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace WeatherMachine.Library.Trebuchet
{
    public interface CalibrationDocument : IEnumerable<CalibrationValue>
    {
        int NbLines { get; }
        int Sum();
    }

    internal class CalibrationValueCollection : CalibrationDocument
    {
        public CalibrationValueCollection(IEnumerable<CalibrationValue> calibrations)
        {
            this.Values = calibrations.ToImmutableList();
            this.NbLines = Values.Count;
        }

        public ImmutableList<CalibrationValue> Values { get; }
        public int NbLines { get; private init; }

        public IEnumerator<CalibrationValue> GetEnumerator()
        {
            return Values.GetEnumerator();
        }

        public int Sum()
        {
            return Values.Select(v => v.Value).Sum();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Values.GetEnumerator();
        }

        public override string ToString()
        {
            return string.Join(',', this.Select(c => c.Value));
        }
    }
}
