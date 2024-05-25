using EBS.Entities;
using EBS.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.Repository.Implementations
{
    public class TicketRepo :ITicketRepo
    {
        private readonly ApplicationDbContext _context;

        public TicketRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<int>> GetBookedTickets(int id)
        {
            var bookedTickets = await _context.Tickets.Include(y => y.Booking).Where(t => t.Booking.EventId == id && t.IsBooked)
                 .Select(t => t.SeatNumber).ToListAsync();

            return bookedTickets;
        }

        public async Task<IEnumerable<Booking>> GetBookings(string userId)
        {
            var bookings = await _context.Bookings.Where(x=>x.UserId==userId)
                .Include(y=>y.Tickets)
                .Include(z=>z.Event)
                .ToListAsync();
            return bookings;
        }

        //50
        //1-10 booked
        //1,31,4

    }
}
