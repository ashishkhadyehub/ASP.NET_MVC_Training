using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Models
{
    public class State
    {
        public int Id { get; set; }

        public string Name { get; set; } = "Maharashtra";

        public int CountryId { get; set; }

        //Navigation Property

        public Country? Country { get; set; }

        //Navigation Property
        public ICollection<District> districts { get; set; } = new HashSet<District>();
    }
}
