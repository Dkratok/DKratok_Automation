using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
    public class Passquantitycalc

    {

        // Count common passenger quantity
        public int Passquantity()
        {
            int CommonPassQuantity = 0;
            
            foreach (PassPlane PP in Aviapark.passengerplanes)
            {
                CommonPassQuantity = CommonPassQuantity + PP.Passengers;
            };
            return CommonPassQuantity;
        }

        // Count common cargo load
        public int Maxload()
        {
            int CommonCargoMaxLoad = 0;
            foreach (Helicopter Helic in Aviapark.helicopters)
            {
                CommonCargoMaxLoad = CommonCargoMaxLoad + Helic.MaxCargoLoad;
            };
            foreach (CargoAirplane CA in Aviapark.cargoplanes)
            {
                CommonCargoMaxLoad = CommonCargoMaxLoad + CA.MaxLoad;
            };
            return CommonCargoMaxLoad; 
            
        }
        }
    }
