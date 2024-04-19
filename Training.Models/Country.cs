using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Models
{
    public class Country
    {
      
        public  int Id { get; set; }

       
        public string Name { get; set; } = "Bharat";

        //Navigation Property
        public ICollection<State> states { get; set; }=new HashSet<State>();
    }
}
