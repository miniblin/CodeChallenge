using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagogoChallenge
{
    /// <summary>
    /// populates the world map with seed data
    /// user can choose how many events to randomly create
    /// </summary>
    public class EventGenerator
    {
        private WorldMap map;
        private Random random = new Random();

        public EventGenerator(int numberOfEvents, WorldMap map)
        {
            this.map = map;
            PopulateMap(numberOfEvents);
        }


        /// <summary>
        /// populates the world map with seed data.
        /// creates a number events and gives each a random amount of 2 differently priced tickets.
        /// if user tries to create more events than map has space for ((map.Size+1)^2), 
        /// the amount of events is reduced to the maximum to prevent infinite looping
        /// </summary>
        /// <param name="numberOfEvents">how many events to create</param>
        public void PopulateMap(int numberOfEvents)
        {
           if(numberOfEvents>((map.Size+1)*(map.Size + 1)))
            {
                numberOfEvents= (map.Size + 1) * (map.Size + 1);
            }
            int i = 0;
            while (i < numberOfEvents)
            {
                int x = random.Next(-(map.Size / 2), (map.Size/2)+1);
                int y = random.Next(-(map.Size / 2), (map.Size / 2)+1);
                               
                try
                {
                    map.AddEvent(x, y);
                    int numberOfTickets = random.Next(1, 20);
                    decimal ticketPrice = (decimal)random.NextDouble() * 50;
                    map.GetEvent(x,y).AddTickets(numberOfTickets, ticketPrice);

                    numberOfTickets = random.Next(1, 20);
                    ticketPrice = (decimal)random.NextDouble() * 50;
                    map.GetEvent(x, y).AddTickets(numberOfTickets, ticketPrice);

                    i++;
                }
                catch (System.ArgumentException)
                {
                   //random generator attempted to write to existing event location
                   //will simply try new location
                }

            }


        }
    }
}
