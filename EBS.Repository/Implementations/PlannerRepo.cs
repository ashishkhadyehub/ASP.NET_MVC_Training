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
    public class PlannerRepo : IPlannerRepo
    {
        private readonly ApplicationDbContext _context;

        public PlannerRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Edit(EventPlanner planner)
        {
            _context.EventPlanners.Update(planner);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<EventPlanner>> GetAll()
        {
            return await _context.EventPlanners.ToListAsync();
        }

        public async Task<EventPlanner> GetById(int id)
        {
            return await _context.EventPlanners.FindAsync(id);
        }

        public async Task RemoveData(EventPlanner planner)
        {
             _context.EventPlanners.Remove(planner);
            await _context.SaveChangesAsync();
        }

        public async Task Save(EventPlanner planner)
        {
           await _context.EventPlanners.AddAsync(planner);
            await _context.SaveChangesAsync();
        }
    }
}
