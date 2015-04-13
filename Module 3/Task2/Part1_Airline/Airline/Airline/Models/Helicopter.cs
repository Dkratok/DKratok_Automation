using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
   public class Helicopter : AviaModel
    {
        
        public int Passengers { get; set; }
        public int MaxCargoLoad { get; set; }
        public Helicopter(string make, int passengers, int maxCargoLoad, int maxLoad, int crew, int flightrange, int maxFlightHeight, string boardNum, bool isMilitary)
        {
            
            this.Make = make;
            this.Passengers = passengers;
            this.MaxCargoLoad = maxCargoLoad;
            this.MaxLoad = maxLoad;
            this.Crew = crew;
            this.Flightrange = flightrange;
            this.MaxFlightHeight = maxFlightHeight;
            this.BoardNum = boardNum;
            this.IsMilitary = isMilitary;

        }
    }
}
