using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.UI.ViewModels
{
    public class EventDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string Image { get; set; }
        public string PlannerImage { get; set; }
        public DateTime DateTime { get; set; }

        public string Venue { get; set; }
        public string VenueAddress { get; set; }

        public string Planner { get; set; }
    }
}
