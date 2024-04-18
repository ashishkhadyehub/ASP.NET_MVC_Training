using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Repositories.Interfaces;

namespace Training.UI.Models.ViewComponents
{
    public class CountryCountViewComponent : ViewComponent
    {
        private readonly ICountryRepo _countryRepo;

        public CountryCountViewComponent(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var countries = await _countryRepo.GetAll();
            int totalCountries=countries.Count();
            return View(totalCountries);
        }
    }
}
