using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.Entities
{
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public int Capacity { get; set; }

        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
