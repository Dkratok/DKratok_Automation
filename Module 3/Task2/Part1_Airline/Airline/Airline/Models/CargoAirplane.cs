using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
     public class CargoAirplane : AviaModel
    {
     

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


             public int flightrange { get; set; }
    }
}
