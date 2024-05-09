using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.UI.ViewModels
{
    public class AvailableTicketsViewModel
    {
        public int EventId { get; set; }

        public string EventName { get; set; }

        public List<int> AvailableSeats { get; set; } 
    }
}
