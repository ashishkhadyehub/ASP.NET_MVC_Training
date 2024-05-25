using EBS.Entities;
using EBS.Repository.Interfaces;
using EBS.UI.Models;
using EBS.UI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace EBS.UI.Controllers
{
    public class HomeController : Controller
    {
       private readonly IEventRepo _eventRepo;
       private readonly ITicketRepo _ticketRepo;
        private readonly IBookingRepo _bookingRepo;

        public HomeController(IEventRepo eventRepo, ITicketRepo ticketRepo, IBookingRepo bookingRepo)
        {
            _eventRepo = eventRepo;
            _ticketRepo = ticketRepo;
            _bookingRepo = bookingRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> EventList()
        {
            DateTime today = DateTime.Today;
            var events = await _eventRepo.GetAll();
            var vm = events.Where(x => x.DateTime >= today).Select(x => new EventListViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.ImageUrl,
                DateTime = x.DateTime,
                Venue = x.Venue.Name,
                Planner = x.Planner.Name,
                Description = x.Description.Substring(0,100)
            }).ToList();
            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var eventvar = await _eventRepo.GetById(id);
            var vm = new EventDetailsViewModel
            {
                Id = eventvar.Id,
                Name = eventvar.Name,
                Description = eventvar.Description,
                DateTime = eventvar.DateTime,
                Planner = eventvar.Planner.Name,
                PlannerImage = eventvar.Planner.ImageUrl,
                Venue = eventvar.Venue.Name,
                VenueAddress = eventvar.Venue.Address,
                Image = eventvar.ImageUrl,

            };
            return View(vm);
        }

        [Authorize]
        public async Task<IActionResult> AvailableTickets(int id)
        {
            var eventvar = await _eventRepo.GetById(id);
            var allSeats = Enumerable.Range(1, eventvar.Venue.Capacity).ToList();
            var bookedTickets = await _ticketRepo.GetBookedTickets(eventvar.Id);

            var availableSeats = allSeats.Except(bookedTickets).ToList();
            var viewModel = new AvailableTicketsViewModel
            {
                EventId = eventvar.Id,
                EventName = eventvar.Name,
                AvailableSeats = availableSeats
            };
            return View(viewModel);
        }


        public async Task<IActionResult> BookTickets(int eventId, List<int> selectedSeats)
        {
            if(selectedSeats==null || selectedSeats.Count==0)
            {
                ModelState.AddModelError("", "No seats selected");
                return RedirectToAction("AvailableTickets", new { id = eventId });
            }
            var claimIdentity=(ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim.Value;

            var newBooking = new Booking
            {
                EventId = eventId,
                BookingDate = DateTime.Now,
                UserId = userId,
            };

            foreach (var seatNo in selectedSeats)
            {
                newBooking.Tickets.Add(new Ticket
                {
                    SeatNumber=seatNo,
                    IsBooked=true
                });
            }

            await _bookingRepo.AddBooking(newBooking);
            return RedirectToAction("Index");


        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
