using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.UI.ViewModels
{
    public class CreatePlannerViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IFormFile ImageUrl { get; set; }
    }
}
