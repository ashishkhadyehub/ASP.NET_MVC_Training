using EBS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.Repository.Interfaces
{
    public interface IVenueRepo
    {
        Task<IEnumerable<Venue>> GetAll();

        Task<Venue> GetById(int id);

        Task Save(Venue venue);

        Task Edit(Venue venue);

        Task RemoveData(Venue venue);
    }
}
