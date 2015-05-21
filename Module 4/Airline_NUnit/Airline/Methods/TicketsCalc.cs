using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Methods
{
    public class TicketsCalc
    {
       public static int BusinessClassTicketPrice = 200;
       public static int FirstClassTicketPrice = 120;
       public static int OtherTicketPrice = 70;
      
        public static int CommonTicketPrice (string Boardnum)
        {
            
            int CommonTicketPrice=0;
            foreach (PassPlane PP in PassPlane.passengerplanes)
            {
                if (PP.BoardNum==Boardnum)
                {
                    CommonTicketPrice=PP.BusinessClassPassengers*BusinessClassTicketPrice+PP.FirstClassPassengers*FirstClassTicketPrice+(PP.Passengers-PP.BusinessClassPassengers-PP.FirstClassPassengers)*OtherTicketPrice;                  
                }
            }
            return CommonTicketPrice;
        }

        public static double AverageTicketPrice(string Boardnum)
        {
            double AverigeTicketPrice = 0;
            
                foreach (PassPlane PP in PassPlane.passengerplanes)
                {
                    if (PP.BoardNum == Boardnum)
                    {
                        AverigeTicketPrice = (PP.BusinessClassPassengers * BusinessClassTicketPrice + PP.FirstClassPassengers * FirstClassTicketPrice + (PP.Passengers - PP.BusinessClassPassengers - PP.FirstClassPassengers) * OtherTicketPrice) / PP.Passengers;
                    }
                }                             
                return AverigeTicketPrice;        
        }
    }
}
