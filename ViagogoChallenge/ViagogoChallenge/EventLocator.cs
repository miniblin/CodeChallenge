using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagogoChallenge
{
    /// <summary>
    /// Handles user interface and input for event location
    /// displays the map to user and asks for a pair of coords.
    /// then reveals the 5 nearest events, the cheapest ticket price, 
    /// and the manhattan distance from the original position.
    /// performs validation on input to ensure the user cant easily break things
    /// </summary>
    public class EventLocator
    {
        int x;
        int y;
        WorldMap map;
        int numberOfEvents;
        bool running;
        public EventLocator(WorldMap map)
        {
            x = 0;
            y = 0;
            numberOfEvents = 5;
            this.map = map;
            running = true;          
        }

        /// <summary>
        ///  Core loop of the event locator program. 
        /// lets user enter coordinate pair and retruieve nearby concerts
        /// user can quit after a search by hitting the "Q" Key
        /// </summary>
        public void Run()
        {
            while (running)
            {
                map.ShowMap();
                Console.WriteLine("Please enter coordinates (in the format x,y) to find nearest Events and prices");
                while (!GetValidInput(Console.ReadLine()))
                {
                    Console.WriteLine("Please enter 2 valid coordinates separated by a comma");
                }
                List<Event> events = map.GetNearestEvents(x, y, numberOfEvents, int.MaxValue);
                DisplayEventData(events);
                Console.WriteLine("\n");
                running = TryAgain();
            }
        }

        public bool TryAgain()
        {
            Console.WriteLine("Press Q to Quit, or any other Key to enter more coordinates");
            String tryAgain=Console.ReadLine();
            return (!(tryAgain.Equals("q")));

        }

        /// <summary>
        /// ensures the input is a valid comma seperate integer pair
        /// catches any exceptions and returns false if input is invalid
        /// </summary>
        /// <param name="input">integer pair(as string)to be parsed </param>
        /// <returns></returns>
        public bool GetValidInput(String input)
        {
           
            if (input == "")
            {
                return false;
            }
            else
            {
                try
                {
                    List<int> coords = input.Split(',').Select(int.Parse).ToList();
                    if (coords.Count != 2)
                    {
                        return false;

                    }
                    else
                    {
                        x = coords[0];
                        y = coords[1];
                        if (x < (-map.Size / 2) || y < (-map.Size / 2) || x > (map.Size / 2) || y > (map.Size / 2))
                        {
                            Console.Write("Coordinates given were not on the map. But the nearest Events to coordinates given are: ");
                        }
                        return true;
                    }
                }
                catch (FormatException)
                {
                    return false;
                }
                
            }
        }
       
        /// <summary>
        /// displays the event data in a readable manner, with formatting and spacing.
        /// </summary>
        /// <param name="events">List of events to display</param>
        public void DisplayEventData(List<Event> events)
        {
            
            Console.WriteLine("\nClosest Events to (" + x + "," + y + ")");
            foreach (Event e in events)
            {
                int distance = Math.Abs(x - e.LocationX) + Math.Abs(y - e.LocationY);
                Console.Write("\n");
                Console.Write("Event: "+ e.Identifier.ToString("D3")+"   ");
                if (e.Tickets.Count > 0)
                {
                    Console.Write("$");
                    Console.Write("{0,5:00.00}", e.CheapestTicket);
                }
                else
                {
                    Console.Write("No Tickets");
                }
                Console.Write("   ");
                Console.Write("{0,-25}", "Distance: " + distance);
                  
            }
        }

        
       public bool Running
        {
            set
            {
                running = value;
            }
        }
    }
}
