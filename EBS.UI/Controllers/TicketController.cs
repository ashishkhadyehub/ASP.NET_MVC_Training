using EBS.Repository.Interfaces;
using EBS.UI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EBS.UI.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketRepo _ticketRepo;

        public TicketController(ITicketRepo ticketRepo)
        {
            _ticketRepo = ticketRepo;
        }

        [Authorize]
        public async Task<IActionResult>  MyTickets()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim.Value;
            var Bookings = await _ticketRepo.GetBookings(userId);
            List<BookingViewModel> vm = new List<BookingViewModel>();
            foreach (var booking in Bookings)
            {
                vm.Add(new BookingViewModel
                {
                    BookingId = booking.BookingId,
                    BookingDate = booking.BookingDate,
                    EventName = booking.Event.Name,
                    Tickets = booking.Tickets.Select(ticketVM => new TicketViewModel { SeatNumber = ticketVM.SeatNumber }).ToList(),
                });
            }
            return View(vm);
            
        }
    }
}
