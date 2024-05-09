using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.Entities
{
    public class Ticket
    {
        public int Id { get; set; }

        public int SeatNumber { get; set; }

        public bool IsBooked { get; set; }
        public int? BookingId { get; set; }

        public Booking Booking { get; set; }
    }
}
