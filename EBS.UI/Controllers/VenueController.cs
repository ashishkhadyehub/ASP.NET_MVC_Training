﻿using EBS.Entities;
using EBS.Repository.Interfaces;
using EBS.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EBS.UI.Controllers
{
    public class VenueController : Controller
    {
        private readonly IVenueRepo _venueRepo;

        public VenueController(IVenueRepo venueRepo)
        {
            _venueRepo = venueRepo;
        }

        public async Task<IActionResult> Index()
        {

            List<VenueViewModel> vm = new List<VenueViewModel>();
            var venues = await _venueRepo.GetAll();
            foreach (var venue in venues)
            {
                vm.Add(new VenueViewModel { Id = venue.Id, Name = venue.Name, Address = venue.Address, Capacity = venue.Capacity });
            }
            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateVenueViewModel vm)
        {
            var venue = new Venue
            {
                Name = vm.Name,
                Address = vm.Address,
                Capacity = vm.Capacity
            };

            await _venueRepo.Save(venue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var venue = await _venueRepo.GetById(id);
            VenueViewModel vm = new VenueViewModel { Id = venue.Id, Name = venue.Name, Address = venue.Address, Capacity = venue.Capacity };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(VenueViewModel vm)
        {
            var venue = new Venue
            {
                Id = vm.Id,
                Name = vm.Name,
                Address = vm.Address,
                Capacity = vm.Capacity

            };
            await _venueRepo.Edit(venue);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var venue = await _venueRepo.GetById(id);
            await _venueRepo.RemoveData(venue);
            return RedirectToAction("Index");
        }
    }
}
