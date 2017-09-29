using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagogoChallenge
{
    /// <summary>
    /// Ticket Class Contains only a orice at the current time.
    /// could later contain more information such as ticket type-standing/sitting
    /// </summary>
    public class Ticket
    {
        private decimal price;

        public Ticket(decimal price)
        {
            this.Price = price;
        }
        
        /// <summary>
        /// Represents the price of the ticket. Can only be a positive decimal number,
        /// otherwise throws Argument Exception.
        /// </summary>
        /// <value>The property gets the value of price, or sets it to a positive value</value>
        public decimal Price
        {
            get { return price; }
            set
            {
                if (value > 0)
                {
                    price = Math.Round(value,2);
                }
                else
                {
                    throw new System.ArgumentException("price of tickets cannot be zero or less", "value");
                }
            }
            
        }


    }
}
