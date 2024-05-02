using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.UI.ViewModels
{
    public class LeaveApplicationListViewModel
    {
        public int Id { get; set; }

        public string EmployeeName { get; set; }

        public string BranchName { get; set; }
        public string DeptName { get; set; }

        public string Category { get; set; }

        [DisplayName("From Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FromDate { get; set; }

        [DisplayName("To Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ToDate { get; set; }


        public string Description { get; set; }
        public string Status { get; set; }

        public int EmployeeId { get; set; }

        [DisplayName("Application Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ApplicationDate { get; set; }
    }
}
