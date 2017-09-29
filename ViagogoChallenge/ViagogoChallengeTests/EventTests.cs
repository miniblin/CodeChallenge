using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViagogoChallenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagogoChallenge.Tests
{
    [TestClass()]
    public class EventTests
    {
       
        [TestMethod()]
        public void AddTicketsTestNormalValues()
        {
            Event event1 = new Event(1,2,3);
            event1.AddTickets(2, 15.50m);           
            event1.AddTickets(3, 12.762m);

            Assert.AreEqual(15.50m, event1.Tickets[0].Price,"Ticket1 Value implemented incorrectly");
            Assert.AreEqual(15.50m, event1.Tickets[1].Price, "Ticket2 Value implemented incorrectly");
            Assert.AreEqual(12.76m, event1.Tickets[2].Price, "Ticket3 Value implemented incorrectly");
            Assert.AreEqual(12.76m, event1.Tickets[3].Price, "Ticket4 Value implemented incorrectly");
            Assert.AreEqual(12.76m, event1.Tickets[4].Price, "Ticket5 Value implemented incorrectly");        
            
        }

        [TestMethod()]
        public void AddTicketsTestCheckCheapestTicket()
        {
            Event event1 = new Event(1, 2, 3);
            event1.AddTickets(2, 15.50m);
            event1.AddTickets(3, 12.76m);
            event1.AddTickets(3, 12.758m);
            event1.AddTickets(3, 14.758m);
            
            Assert.AreEqual(12.76m, event1.CheapestTicket, "Cheapest ticket updated incorrectly");

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "zero tickets were inappropriately allowed.")]
        public void AddTicketsTestZeroTickets()
        {
            Event event1 = new Event(1, 2, 3);
            event1.AddTickets(0, 15.50m);
                       

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "negative tickets were inappropriately allowed.")]
        public void AddTicketsTestNegativeTickets()
        {
            Event event1 = new Event(1, 2, 3);
            event1.AddTickets(-5, 15.50m);


        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "zero price were inappropriately allowed.")]
        public void AddTicketsTestZeroPrice()
        {
            Event event1 = new Event(1, 2, 3);
            event1.AddTickets(2, 0m);


        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "negative price tickets were inappropriately allowed.")]
        public void AddTicketsTestNegativePrice()
        {
            Event event1 = new Event(1, 2, 3);
            event1.AddTickets(2, -15.50m);


        }

    }
}