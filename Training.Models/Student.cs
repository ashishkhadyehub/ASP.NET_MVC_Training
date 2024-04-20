using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Student Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Contact Number")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "The Contact Number must be exactly 10 digits.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "The Contact Number must contain only digits.")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }
    }
}
