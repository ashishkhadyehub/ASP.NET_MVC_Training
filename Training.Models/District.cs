using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Models
{
    public class District
    {
        public int Id { get; set; }

        public string Name { get; set; } = "Kolhapur";

        public int StateId { get; set; }

        //Navigation Property
        public State? State { get; set; }
    }
}
