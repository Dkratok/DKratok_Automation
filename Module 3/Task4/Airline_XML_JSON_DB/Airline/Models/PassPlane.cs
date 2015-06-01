using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
     [Serializable]
    public class PassPlane : AviaModel
    {
        public PassPlane() { }
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
        public static List<PassPlane> passengerplanes = new List<PassPlane>
        {
         new PassPlane(170, 70, 0, 100, 4, 6000, 12100, "TU-164", "T456Y", false),
         new PassPlane(36, 0, 0, 17, 4, 2000, 6000, "JAC-40", "SF573", false),
         new PassPlane(220, 50, 30, 116, 2, 7800, 12800, "Boeing 757", "BG459", false),
         new PassPlane(120, 40, 20, 70, 3, 6000, 12000, "Airbus A320", "A4FR5", false),
         new PassPlane(130, 40, 30, 70, 3, 6000, 12000, "Airbus A320", "A4FR6", false)
        };
    }
}
