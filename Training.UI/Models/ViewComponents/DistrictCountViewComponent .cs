using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Repositories.Interfaces;

namespace Training.UI.Models.ViewComponents
{
    public class DistrictCountViewComponent : ViewComponent
    {
        private readonly IDistrictRepo _districtrepo;

        public DistrictCountViewComponent(IDistrictRepo districtrepo)
        {
            _districtrepo = districtrepo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var districts = await _districtrepo.GetAll();
            int totalDistricts=districts.Count();
            return View(totalDistricts);
        }
    }
}
