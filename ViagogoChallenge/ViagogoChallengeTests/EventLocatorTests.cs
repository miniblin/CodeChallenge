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
    public class EventLocatorTests
    {
        [TestMethod()]
        public void GetValidInputTestEmpty()
        {
            WorldMap map = new WorldMap(10);
            EventLocator eventLocator = new EventLocator(map);

            bool isValid;
            isValid= eventLocator.GetValidInput("");
            Assert.AreEqual(false, isValid, "did not fail on empty space");

        }

        [TestMethod()]
        public void GetValidInputTestWrongFormat()
        {
            WorldMap map = new WorldMap(10);
            EventLocator eventLocator = new EventLocator(map);

            bool isValid;
            isValid = eventLocator.GetValidInput("3,3,3");
            Assert.AreEqual(false, isValid, "did not fail on incorrectly formatted coordinates");

        }

        [TestMethod()]
        public void GetValidInputTestValid()
        {
            WorldMap map = new WorldMap(10);
            EventLocator eventLocator = new EventLocator(map);

            bool isValid;
            isValid = eventLocator.GetValidInput("3,3");
            Assert.AreEqual(true, isValid, "did not fail on incorrectly formatted coordinates");

        }

        [TestMethod()]
        public void GetValidInputTestNotANumber()
        {
            WorldMap map = new WorldMap(10);
            EventLocator eventLocator = new EventLocator(map);

            bool isValid;
            isValid = eventLocator.GetValidInput("hello");
            Assert.AreEqual(false, isValid, "did not fail on incorrectly formatted coordinates");

        }

        
        
    }
}