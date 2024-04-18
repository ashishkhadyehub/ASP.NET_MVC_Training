using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Repositories.Interfaces;

namespace Training.UI.Models.ViewComponents
{
    public class StateCountViewComponent : ViewComponent
    {
        private readonly IStateRepo _stateRepo;

        public StateCountViewComponent(IStateRepo stateRepo)
        {
            _stateRepo = stateRepo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var states = await _stateRepo.GetAll();
            int totalStates= states.Count();    
            return View(totalStates);
        }
    }
}
