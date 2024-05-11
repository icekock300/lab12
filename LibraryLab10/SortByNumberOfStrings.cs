using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLab10
{
    public class SortByNumberOfStrings : IComparer
    {
        public int Compare(object? x, object? y)
        {
            Guitar g1 = x as Guitar;
            Guitar g2 = y as Guitar;

            if (g1.NumberOfGuitarStrings < g2.NumberOfGuitarStrings) return -1;
            else
                if (g1.NumberOfGuitarStrings == g2.NumberOfGuitarStrings) return 0;
            else return 1;
        }
    }
}
