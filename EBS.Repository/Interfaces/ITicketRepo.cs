using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.Repository.Interfaces
{
    public interface ITicketRepo
    {
        Task<IEnumerable<int>> GetBookedTickets(int eventId);
    }
}
