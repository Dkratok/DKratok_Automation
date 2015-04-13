using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
    public class PassPlane : AviaModel
    {
        public int Passengers { get; set; }
        public int FirstClassPassengers { get; set; }
        public int BusinessClassPassengers { get; set; }
        public PassPlane(int passengers, int firstClassPassengers, int businessClassPassengers, int maxLoad, int crew, int flightrange, int maxFlightHeight, string make, string boardNum, bool isMilitary)
        {
            this.Passengers = passengers;
            this.FirstClassPassengers = firstClassPassengers;
            this.BusinessClassPassengers = businessClassPassengers;
            this.MaxLoad = maxLoad;
            this.Crew = crew;
            this.Flightrange = flightrange;
            this.MaxFlightHeight = maxFlightHeight;
            this.Make = make;
            this.BoardNum = boardNum;
            this.IsMilitary = isMilitary;

        }

    }
}
