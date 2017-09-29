using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagogoChallenge
{
    /// <summary>
    /// creates a world map, seeds it with event data and starts eventLocator running 
    /// All unit tests Pass succesfully.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            WorldMap map = new WorldMap(10);
            EventGenerator generator = new EventGenerator(50, map);
            EventLocator eventLocator = new EventLocator(map);
            eventLocator.Run();
           
        }
    }
}
