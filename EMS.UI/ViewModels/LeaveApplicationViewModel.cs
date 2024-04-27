using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.UI.ViewModels
{
    public class LeaveApplicationViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select category")]
        public string Category { get; set; }

        [DisplayName("From Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]

        [Required(ErrorMessage = "Please select fromdate")]
        public DateTime FromDate { get; set; }

        [DisplayName("To Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]

        [Required(ErrorMessage = "Please select todate")]
        public DateTime ToDate { get; set; }

        [Required(ErrorMessage = "Please enter description")]
        public string Description { get; set; }

        [DisplayName("Application Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ApplicationDate { get; set; }

        public int EmployeeId { get; set; }

        public string Status { get; set; }
    }
}
