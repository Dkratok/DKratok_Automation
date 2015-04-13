using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
    abstract public class AviaModel
    {
        public int Crew { get; set; }
        public int Flightrange { get; set; }
        public int MaxFlightHeight { get; set; }
        public string Make { get; set; }
        public string BoardNum { get; set; }
        public Boolean IsMilitary { get; set; }
        public int MaxLoad { get; set; }

    }
}
