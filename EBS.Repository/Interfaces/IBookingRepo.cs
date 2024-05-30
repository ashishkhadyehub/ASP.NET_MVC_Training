using EBS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.Repository.Interfaces
{
    public interface IBookingRepo 
    {
        Task AddBooking(Booking booking);

        Task<IEnumerable<Booking>> GetAll(int id);
    }
}
