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
    public class EventGeneratorTests
    {
       
        [TestMethod()]
        public void PopulateMapTest()
        {
            WorldMap map = new WorldMap(10);
            EventGenerator generator = new EventGenerator(99, map);
            List<Event> nearestEvents = map.GetNearestEvents(0, 0, 200, 100);
            Assert.AreEqual(99,nearestEvents.Count , "99 events not placed correctly");
           
        }



        [TestMethod()]
        public void PopulateMapTestMaximumEvents()
        {
            WorldMap map = new WorldMap(10);
            EventGenerator generator = new EventGenerator(441, map);
            List<Event> nearestEvents = map.GetNearestEvents(0, 0, 500, 100);
            Assert.AreEqual(441, nearestEvents.Count, "could not fill in entire map");

        }

        [TestMethod()]
        public void PopulateMapTestMoreThanMaximumEvents()
        {
            WorldMap map = new WorldMap(10);
            EventGenerator generator = new EventGenerator(445, map);
            List<Event> nearestEvents = map.GetNearestEvents(0, 0, 500, 100);
            Assert.AreEqual(441, nearestEvents.Count, "could not deal with more events than map could handle");

        }

        [TestMethod()]
        public void PopulateMapTestZeroEvents()
        {
            WorldMap map = new WorldMap(10);
            EventGenerator generator = new EventGenerator(0, map);
            List<Event> nearestEvents = map.GetNearestEvents(0, 0, 500, 100);
            Assert.AreEqual(0, nearestEvents.Count, "0 events not placed correctly");

        }

        [TestMethod()]
        public void PopulateMapTestCheckTickets()
        {
            WorldMap map = new WorldMap(10);
            EventGenerator generator = new EventGenerator(99, map);
            List<Event> nearestEvents = map.GetNearestEvents(0, 0, 99, 100);

            for (int i = 0; i < 99; i++)
            {
                Assert.IsTrue(nearestEvents[i].Tickets.Count > 0, "not all events have tickets");

            }
        }

        

    }
}