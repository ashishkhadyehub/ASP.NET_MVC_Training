using EBS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.Repository.Interfaces
{
    public interface IEventRepo
    {
        Task<IEnumerable<Event>> GetAll();

        Task<Event> GetById(int id);

        Task Save(Event varevent);

        Task Edit(Event varevent);

        Task RemoveData(Event varevent);
    }
}
