using EBS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.Repository.Interfaces
{
    public interface IPlannerRepo
    {
        Task<IEnumerable<EventPlanner>> GetAll();

        Task<EventPlanner> GetById(int id);

        Task Save(EventPlanner planner);

        Task Edit(EventPlanner planner);

        Task RemoveData(EventPlanner planner);
    }
}
