using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
    public class PlaneCalculation

    {

        // Count common crew quantity
        public int Crew()
        {
            int CommonCrew = 0;

            foreach (AviaModel AM in AviaModel.planes)
            {
                CommonCrew = CommonCrew + AM.Crew;
            };
            return CommonCrew;
        }

        // Count common flight range
        public int FlightRange()
        {
            int CommonRange = 0;

            foreach (AviaModel AM in AviaModel.planes)
            {
                CommonRange = CommonRange + AM.Flightrange;
            };
            return CommonRange;
        }
        }
    }
