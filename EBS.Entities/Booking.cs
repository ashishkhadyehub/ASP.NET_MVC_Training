using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.Entities
{
    public class Booking
    {
        public int BookingId { get; set; }

        public DateTime BookingDate { get; set; }

        public int EventId { get; set; }

        public Event Event { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
