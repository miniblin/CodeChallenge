using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagogoChallenge
{
    /// <summary>
    /// The worldMap Stores Each event at a world-location using a 2 dimensional array.
    /// This can be inefficient for a large map that is sparsely populated,
    /// but for a small map, with many events it provides very efficient neighbour searching.
    /// The map could be extended to allow multiple events at each location by having a 2d array of Event Lists.
    /// In a real world setting this data wouold morelikely be stored in an Relational DB
    /// </summary>
    public class WorldMap
    {
        private Event[,] events;
        private int size;
        private int identifier;

        /// <summary>
        /// Given the maximum x and y positions, creates a map that spans the same distance in the negative axis.
        /// </summary>
        /// <param name="maximumXY">maximum XY coordinates desired</param>
        public WorldMap(int maximumXY)
        {
            size = maximumXY * 2;
            events = new Event[size + 1, size + 1];
            identifier = 1;
        }

        /// <summary>
        /// Adds an event to the world map at the coordinate given. 
        /// converts from world-space to array space
        /// Ensures that ony one event is added to each position,
        /// Ensures that the location is on the map.
        /// </summary>
        /// <param name="x">world spcae x coordinate to add location</param>
        /// <param name="y">world spcae y coordinate to add location</param>
        /// <returns></returns>
        public bool AddEvent(int x, int y)
        {
            int arrayX = x + (size / 2);
            int arrayY = y + (size / 2);
            if (arrayX < 0 || arrayX > size )
            {
                throw new System.ArgumentException("coordinates out of bounds", "x");
            }
            else if(arrayY < 0 || arrayY > size)
            {
                throw new System.ArgumentException("coordinates out of bounds", "y");
            }
            else if (events[arrayX, arrayY] == null)
            {
                events[arrayX, arrayY] = new Event(identifier, x, y);
                identifier++;
                return true;
            }
            else
            {
                throw new System.ArgumentException("event already exists in this location", "x,y");
            }

        }


        /// <summary>
        /// Given a pair of coordinates in the negative-positive world space, spirals outward searching the array for the nearest events.
        /// uses manhattan distance to find verticaly/horizontaly adjacent neighbours before diagonal.
        /// Will find neighbours even if originaly given a position not on the map.
        /// </summary>
        /// <param name="x">starting x search coordinate in the negative-positve world space</param>
        /// <param name="y">starting y search coordinate in the negative-positve world space</param>
        /// <param name="numberOfEvents">how many neighbour events to find</param>
        /// <param name="maxDistance">maximum distance to search. useful in the event there are no neighbours. prevents looping forever.</param>
        /// <returns></returns>
        public List<Event> GetNearestEvents(int x, int y, int numberOfEvents, int maxDistance)
        {
            int eventsFound = 0;
            List<Event> nearbyEvents = new List<Event>();

            
            int checkX=x;
            int checkY=y;

            if (GetEvent(checkX, checkY) != null && eventsFound < numberOfEvents)
            {
                nearbyEvents.Add(GetEvent(checkX, checkY));
                eventsFound++;
            }

            int distance = 1;
            while (eventsFound < numberOfEvents && distance <= maxDistance)
            {
                for (int i = 0; i < distance + 1; i++)
                {
                    checkX = x - distance + i;
                    checkY = y - i;

                    if (GetEvent(checkX, checkY) != null  &&eventsFound<numberOfEvents)
                    {
                        nearbyEvents.Add(GetEvent(checkX, checkY));
                        eventsFound++;
                    }
                    
                    checkX = x + distance - i;
                    checkY = y + i;
                    if (GetEvent(checkX, checkY) != null && eventsFound < numberOfEvents)
                    {
                        nearbyEvents.Add(GetEvent(checkX, checkY));
                        eventsFound++;
                    }

                }
                
                for (int i = 1; i < distance; i++)
                {
                    checkX = x - i;
                    checkY = y + distance - i;
                    if (GetEvent(checkX, checkY) != null && eventsFound < numberOfEvents)
                    {
                        nearbyEvents.Add(GetEvent(checkX, checkY));
                        eventsFound++;
                    }


                    checkX = x + distance - i;
                    checkY = y - i;
                    if (GetEvent(checkX, checkY) != null && eventsFound < numberOfEvents)
                    {
                        nearbyEvents.Add(GetEvent(checkX, checkY));
                        eventsFound++;
                    }

                }
                distance++;
            }
            return nearbyEvents;
        }


        /// <summary>
        /// Checks the coord is within the bounds of the array and returns the event
        /// at the position if it exists.
        /// converts from the negative-positive world space to the array space
        /// </summary>
        /// <param name="x">x coordinate in the negative-positve world space</param>
        /// <param name="y">y coordinate in the negative-positve world space</param>
        /// <returns></returns>
        public Event GetEvent(int x, int y)
        {
            x += size / 2;
            y += size / 2;

            if (x >= 0 && y >= 0 && x <= size && y <= size)
            {
                return (events[x, y]);
            }
            else
            {
                return null;
            }

        }
        
        /// <summary>
        /// Displays an ASCII Art Version of The Event Map
        /// works well with -10 to +10,  currently has some issues with very large or very small maps.
        /// </summary>
        public void ShowMap()
        {
            Console.Write("{0,6}", "  ");
            for (int i = 0; i <= size; i++)
            {
                Console.Write("{0,3}", i - (size / 2));
            }
            Console.Write("\n\n");

            for (int i = 0; i <= size; i++)
            {
                Console.Write("{0,4}", i - (size / 2));
                Console.Write("{0,3}", "|");
                for (int j = 0; j <= size; j++)
                {
                    if (events[j, i] != null)
                    {
                        Console.Write("{0,3}", events[j, i].Identifier + "|");
                    }
                    else
                    {
                        Console.Write("{0,3}", "|");
                    }
                }
                Console.Write("\n");
            }
        }

        public Event[,] Events
        {
            get { return events; }
        }

        public int Size
        {
            get { return size; }
        }
        
    }
}
