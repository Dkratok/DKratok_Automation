using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
     [Serializable]
   public class Helicopter : AviaModel
    {
         public Helicopter() : base() { }
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

        public static List<Helicopter> helicopters = new List<Helicopter>
        {
            new Helicopter("MI-8", 25, 15, 11, 3, 500, 5000,  "M767H1", false),
            new Helicopter("MI-8", 27, 17, 11, 3, 550, 5000,  "M767H2", false),
            new Helicopter("MI-24", 8, 4, 15, 3, 600, 4500, "M34RF1", true)
        };
    }
}
