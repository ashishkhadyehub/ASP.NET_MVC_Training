using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public string Branch { get; set; }
        public string Department { get; set; }

        public string? PhotoURL { get; set; }
        public string Password { get; set; }

        public DateTime RegisterDate { get; set; }
    }
}
