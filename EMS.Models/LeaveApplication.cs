using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class LeaveApplication
    {
        public int Id { get; set; }

        public string Category { get; set; }
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }
        public string Description { get; set; }
        public DateTime ApplicationDate { get; set; }

        public int EmployeeId { get; set; }

        public string Status { get; set; }
        public Employee? Employee { get; set; }
    }
}
