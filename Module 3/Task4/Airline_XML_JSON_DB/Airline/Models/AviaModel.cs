using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
    [Serializable]
    abstract public class AviaModel
    {
        public AviaModel() { }
        public int Crew { get; set; }
        public int Flightrange { get; set; }
        public int MaxFlightHeight { get; set; }
        public string Make { get; set; }
        public string BoardNum { get; set; }
        public Boolean IsMilitary { get; set; }
        public int MaxLoad { get; set; }

        public static List<AviaModel> planes = new List<AviaModel>
        {
         new PassPlane(170, 70, 0, 100, 4, 6000, 12100, "TU-164", "T456Y", false),
         new PassPlane(36, 0, 0, 17, 4, 2000, 6000, "JAC-40", "SF573", false),
         new PassPlane(220, 50, 30, 116, 2, 7800, 12800, "Boeing 757", "BG459", false),
         new PassPlane(120, 40, 20, 70, 3, 6000, 12000, "Airbus A320", "A4FR5", false),
         new PassPlane(130, 40, 30, 70, 3, 6000, 12000, "Airbus A320", "A4FR6", false),
         new CargoAirplane(37, 141, 4, 7800, 12200, "Airbus A400M", "G456Y", false),
         new CargoAirplane(60, 120, 7, 5200, 10000, "AN-22", "SF573", false),
         new CargoAirplane(55, 210, 5, 6000, 11000, "IL-76", "G456Y", false), 
         new CargoAirplane(55, 300, 5, 6000, 11000, "IL-76", "G456Y", false),        
         new CargoAirplane(55, 500, 5, 6000, 11000, "IL-76", "G458Y", false), 
         new CargoAirplane(55, 400, 5, 6000, 11000, "IL-76", "G457Y", false),
         new Helicopter("MI-8", 25, 15, 11, 3, 500, 5000,  "M767H1", false),
         new Helicopter("MI-8", 27, 17, 11, 3, 550, 5000,  "M767H2", false),
         new Helicopter("MI-24", 8, 4, 15, 3, 600, 4500, "M34RF1", true)
        };


        public static void Sortby()
        {
            AviaModel.planes.Sort(delegate(AviaModel x, AviaModel y)
            {
                return x.MaxLoad.CompareTo(y.MaxLoad);

            });
        }
    }
}
