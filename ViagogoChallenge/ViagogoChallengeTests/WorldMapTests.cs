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
    public class WorldMapTests
    {
        [TestMethod()]
        public void GetNearestEventsTestLimitedResults()
        {
            WorldMap map = new WorldMap(10);
            map.AddEvent(5,5);
            map.AddEvent(4,5);
            map.AddEvent(8,5);
            map.AddEvent(-1 ,8);
            map.AddEvent(5,6);
            map.AddEvent(-5, 7);

            List <Event> nearestEvents = map.GetNearestEvents(5, 5, 5, 100);
            Assert.AreEqual(1, nearestEvents[0].Identifier, "nearby Events Calculated incorrectly");
            Assert.AreEqual(2, nearestEvents[1].Identifier, "nearby Events Calculated incorrectly");
            Assert.AreEqual(5, nearestEvents[2].Identifier, "nearby Events Calculated incorrectly");
            Assert.AreEqual(3, nearestEvents[3].Identifier, "nearby Events Calculated incorrectly");
            Assert.AreEqual(4, nearestEvents[4].Identifier, "nearby Events Calculated incorrectly");
            
        }

        [TestMethod()]
        public void GetNearestEventsTestGetAllResults()
        {
            WorldMap map = new WorldMap(10);
            map.AddEvent(5, 5);
            map.AddEvent(4, 5);
            map.AddEvent(8, 5);
            map.AddEvent(-1, 8);
            map.AddEvent(5, 6);
            map.AddEvent(-5, 7);

            List<Event> nearestEvents = map.GetNearestEvents(5, 5, 6, 100);
            Assert.AreEqual(1, nearestEvents[0].Identifier, "nearby Events Calculated incorrectly");
            Assert.AreEqual(2, nearestEvents[1].Identifier, "nearby Events Calculated incorrectly");
            Assert.AreEqual(5, nearestEvents[2].Identifier, "nearby Events Calculated incorrectly");
            Assert.AreEqual(3, nearestEvents[3].Identifier, "nearby Events Calculated incorrectly");
            Assert.AreEqual(4, nearestEvents[4].Identifier, "nearby Events Calculated incorrectly");
            Assert.AreEqual(6, nearestEvents[5].Identifier, "nearby Events Calculated incorrectly");

        }

        [TestMethod()]
        public void GetNearestEventsTestLimitDistance()
        {
            WorldMap map = new WorldMap(10);
            map.AddEvent(5, 5);
            map.AddEvent(4, 5);
            map.AddEvent(8, 5);
            map.AddEvent(-1, 8);
            map.AddEvent(5, 6);
            map.AddEvent(-5, 7);

            List<Event> nearestEvents = map.GetNearestEvents(5, 5, 6, 3);
            Assert.AreEqual(1, nearestEvents[0].Identifier, "nearby Events Calculated incorrectly");
            Assert.AreEqual(2, nearestEvents[1].Identifier, "nearby Events Calculated incorrectly");
            Assert.AreEqual(5, nearestEvents[2].Identifier, "nearby Events Calculated incorrectly");
            Assert.AreEqual(3, nearestEvents[3].Identifier, "nearby Events Calculated incorrectly");

            Assert.AreEqual(4, nearestEvents.Count, "too many or too few events found");

        }

        [TestMethod()]
        public void GetNearestEventsNoEvents()
        {
            WorldMap map = new WorldMap(10);
            List<Event> nearestEvents = map.GetNearestEvents(5, 5, 6, 3);
            Assert.AreEqual(0, nearestEvents.Count, "events were found when none should exist");

        }

        [TestMethod()]
        public void GetNearestEventsLocationOffMap()
        {
            WorldMap map = new WorldMap(10);
            map.AddEvent(-10, -10);//1
            map.AddEvent(-8, -5);//2
            map.AddEvent(0, 0);//4
            map.AddEvent(-6, 0);//3
            map.AddEvent(10, 10);//6
            map.AddEvent(3, 3);//5
            List<Event> nearestEvents = map.GetNearestEvents(-30, -10, 6, 100);
            
            Assert.AreEqual(1, nearestEvents[0].Identifier, "nearby Events Calculated incorrectly when start location not on map");
            Assert.AreEqual(2, nearestEvents[1].Identifier, "nearby Events Calculated incorrectly when start location not on map");
            Assert.AreEqual(4, nearestEvents[2].Identifier, "nearby Events Calculated incorrectly when start location not on map");
            Assert.AreEqual(3, nearestEvents[3].Identifier, "nearby Events Calculated incorrectly when start location not on map");
            Assert.AreEqual(6, nearestEvents[4].Identifier, "nearby Events Calculated incorrectly when start location not on map");
            Assert.AreEqual(5, nearestEvents[5].Identifier, "nearby Events Calculated incorrectly when start location not on map");
            
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "out of bounds event was inapropriately allowed")]
        public void AddEventTestOutOfBounds()
        {
            WorldMap map = new WorldMap(10);
            map.AddEvent(-11, 0);
           
        }

        [TestMethod]
        public void AddEventTestBoundary()
        {
            WorldMap map = new WorldMap(10);
            map.AddEvent(-10, -10);
            map.AddEvent(-10, 0);
            map.AddEvent(10, 10);
            map.AddEvent(0, 10);
            map.AddEvent(0, -10);
            map.AddEvent(10, 0);
            Assert.AreEqual(1, map.GetEvent(-10,-10).Identifier, "Event added incorrectly");
            Assert.AreEqual(2, map.GetEvent(-10, 0).Identifier, "Event added incorrectly");
            Assert.AreEqual(3, map.GetEvent(10, 10).Identifier, "Event added incorrectly");
            Assert.AreEqual(4, map.GetEvent(0,10).Identifier, "Event added incorrectly");
            Assert.AreEqual(5, map.GetEvent(0, -10).Identifier, "Event added incorrectly");
            Assert.AreEqual(6, map.GetEvent(10, 0).Identifier, "Event added incorrectly");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
       "multiple events were inapropriately allowed at same location")]
        public void AddEventTestMultipleEventsSameLocation()
        {
            WorldMap map = new WorldMap(10);
            map.AddEvent(4, 3);
            map.AddEvent(4, 3);

        }

        

    }
}