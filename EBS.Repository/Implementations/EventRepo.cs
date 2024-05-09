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
    public class EventRepo : IEventRepo
    {
        private readonly ApplicationDbContext _context;

        public EventRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Edit(Event varevent)
        {
            _context.Events.Update(varevent);
            await _context.SaveChangesAsync();  
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            return await _context.Events.Include(x=>x.Venue).Include(y=>y.Planner).ToListAsync();
        }

        public async Task<Event> GetById(int id)
        {
            return await _context.Events.Include(x => x.Venue).Include(y => y.Planner).FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task RemoveData(Event varevent)
        {
            _context.Events.Remove(varevent);
            await _context.SaveChangesAsync();
        }

        public async Task Save(Event varevent)
        {
            await _context.Events.AddAsync(varevent);
            await _context.SaveChangesAsync();
        }
    }
}
