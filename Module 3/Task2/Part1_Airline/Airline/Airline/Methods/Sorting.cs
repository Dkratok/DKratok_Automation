using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
    
    // Sorting helicopters by max cargo load
    public class Sorting
    {
        public static void Sort1()
        {
            Aviapark.helicopters.Sort(delegate(Helicopter x, Helicopter y)
            {
                return x.MaxCargoLoad.CompareTo(y.MaxCargoLoad);
            });
        }
       
    }
}
