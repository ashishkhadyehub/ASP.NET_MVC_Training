using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.UI.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Contact Number")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "The Contact Number must be exactly 10 digits.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "The Contact Number must contain only digits.")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }
        public string Address { get; set; }

        [DisplayName("Branch")]
        [Required(ErrorMessage = "Please select branch")]

        public string EmpBranch { get; set; }

        [DisplayName("Department")]

        [Required(ErrorMessage = "Please select department")]
        public string EmpDepartment { get; set; }

        [DisplayName("Select Profile Photo")]
        public IFormFile PhotoURL { get; set; }


        [Required(ErrorMessage = "Please set password")]
        public string Password { get; set; }

        public DateTime RegisterDate { get; set; }

        public string DbPath { get; set; }
    }
}
