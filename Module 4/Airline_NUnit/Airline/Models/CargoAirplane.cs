using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
     [Serializable]
     public class CargoAirplane : AviaModel
    {
         public CargoAirplane() : base() { }
              public int MaxCargoLoad { get; set; }
              public CargoAirplane(int maxCargoLoad, int maxLoad, int crew, int flightrange, int maxFlightHeight, string make, string boardNum, bool isMilitary)
              {                
                  this.MaxCargoLoad = maxCargoLoad;
                  this.MaxLoad = maxLoad;
                  this.Crew = crew;
                  this.Flightrange = flightrange;
                  this.MaxFlightHeight = maxFlightHeight;
                  this.Make = make;
                  this.BoardNum = boardNum;
                  this.IsMilitary = isMilitary;
              }

              public static List<CargoAirplane> cargoplanes = new List<CargoAirplane>
        {
         new CargoAirplane(37, 141, 4, 7800, 12200, "Airbus A400M", "G456Y", false),
         new CargoAirplane(60, 120, 7, 5200, 10000, "AN-22", "SF573", false),
         new CargoAirplane(55, 210, 5, 6000, 11000, "IL-76", "G456Y", false), 
         new CargoAirplane(55, 300, 5, 6000, 11000, "IL-76", "G456Y", false),        
         new CargoAirplane(55, 500, 5, 6000, 11000, "IL-76", "G458Y", false), 
         new CargoAirplane(55, 400, 5, 6000, 11000, "IL-76", "G457Y", false)         
        };
             //public override double CommonCrewSalary(int crew)
             //{
             //    CrewSalary1 = Crew * AverigeSalary * 1.1;
             //    return CrewSalary1;
             //}
    }
}
