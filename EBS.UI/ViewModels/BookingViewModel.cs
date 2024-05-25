using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.UI.ViewModels
{
    public class BookingViewModel
    {
        public int BookingId { get; set; }

        public DateTime BookingDate { get; set; }

        public string EventName { get; set; }

        public List<TicketViewModel> Tickets { get; set; }
    }
}
