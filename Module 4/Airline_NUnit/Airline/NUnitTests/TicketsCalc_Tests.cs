using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Airline.NUnitTests
{
    [TestFixture]
    [Category("Positive")]
    public class TicketsCalc_Positive
    {
        //Parametrized test
        [Test, Sequential]
        public void VerifyCommonTicketPricePositive([Values("A4FR5", "BG459", "T456Y")]  string BoardNumPosParam, [Values(13000, 21800, 15400)]  int CommonTicketPriceCounted)
        {
            int CommonTicketPrice = Methods.TicketsCalc.CommonTicketPrice(BoardNumPosParam);
            Assert.IsTrue(CommonTicketPrice == CommonTicketPriceCounted, "Common Ticket Price is correctly calculated.");
        }

        [Test]
        public void VerifyAverageTicketPricePositive()
        {
            double AverageTicketPrice = Methods.TicketsCalc.AverageTicketPrice(NUnitTests.Testdata.BoardNumPos);
            Assert.IsTrue(AverageTicketPrice == NUnitTests.Testdata.AverageTicketPricePosTestData, "Average Class Ticket Price is correctly calculated.");
        }
    

      [Test]
      [Ignore("Ignore a test")]
        public void VerifyAverageTicketPricePositiveIgnored()
        {
            double AverageTicketPrice = Methods.TicketsCalc.AverageTicketPrice(NUnitTests.Testdata.BoardNumPos);
            Assert.IsTrue(AverageTicketPrice == NUnitTests.Testdata.AverageTicketPricePosTestData, "Average Class Ticket Price is correctly calculated.");
        }

    }
        [TestFixture]
        [Category("Negative")]
    public class TicketsCalc_TestsNegative
    {
       
        [Test]
        public void VerifyCommonTicketPriceNegative()
        {
            int CommonTicketPrice = Methods.TicketsCalc.CommonTicketPrice(NUnitTests.Testdata.BoardNumNotExisted);
            Assert.IsTrue(CommonTicketPrice == 0, "A plane with this board number does not exist.");
        }

        [Test]
        public void VerifyAverageTicketPriceNegative()
        {
            double AverageTicketPrice = Methods.TicketsCalc.AverageTicketPrice(NUnitTests.Testdata.BoardNumNotExisted);
            Assert.IsTrue(AverageTicketPrice == 0, "A plane with this board number does not exist.");
        }
        
     }

        [TestFixture]
        [Category("Failed")]
        public class TicketsCalc_TestsFailed
        {
        
        [Test]
        public void VerifyAverageTicketPriceFailed()
        {
            double AverageTicketPrice = Methods.TicketsCalc.AverageTicketPrice(NUnitTests.Testdata.BoardNumPos);
            Assert.IsTrue(AverageTicketPrice == null, "A plane with this board number does exist. Test failed");
        }
    }
}
