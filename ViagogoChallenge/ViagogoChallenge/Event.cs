using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagogoChallenge
{
    /// <summary>
    /// Event class stores information for each event, such as the tickets,
    /// the location and the value of the cheapest ticket.
    /// Each event has a unique identifier, identifier is set and incremented in the WorldMap Cass
    /// when an event is created
    /// </summary>
    public class Event
    {
        // Would normaly store events in MySQL DB, identifier being unique key
        private int identifier;        
        private decimal cheapestTicket;       
        private List<Ticket> tickets;
        private int locationX;
        private int locationY;
        
        public Event(int identifier, int locationX, int locationY)
        {
            this.identifier = identifier;
            tickets = new List<Ticket>();
            cheapestTicket = decimal.MaxValue;
            this.locationX = locationX;
            this.locationY = locationY;
           
        }

        /// <summary>
        /// Add Tickets to an event, ensures that tickets have a positive Decimal value,
        /// and that a none-zero number of tickets have been added. The value of the cheapest ticket is updated at this point.
        /// </summary>
        /// <param name="numberOfTickets">number of tikets to add</param>
        /// <param name="price">price of the tickets being added</param>
        public void AddTickets(int numberOfTickets, decimal price)
        {
            if (numberOfTickets <= 0)
            {
                throw new System.ArgumentException("number of tickets cannot be zero or less", "numberOfTickets");
            }
            else if(price <= 0)
            {
                throw new System.ArgumentException("price of tickets cannot be zero or less", "price");
            }       
                     
            else
            {
                price = Math.Round(price, 2);
                if (price <= cheapestTicket)
                {
                    cheapestTicket = price;
                }
                for(int i = 0; i < numberOfTickets; i++)
                {                    
                    tickets.Add(new Ticket(price));
                   
                }
            }
           
            
        }


        public decimal CheapestTicket
        {
            get { return cheapestTicket; }

        }

        public List<Ticket> Tickets
        {
            get { return tickets; }
        }

        public int Identifier
        {
            get { return identifier; }
        }

        public int LocationX
        {
            get { return locationX; }
        }

        public int LocationY
        {
            get { return locationY; }
        }
        //deplete tickets

    }
}
