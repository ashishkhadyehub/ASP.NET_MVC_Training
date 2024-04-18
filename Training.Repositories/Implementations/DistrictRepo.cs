using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Models;
using Training.Repositories.Interfaces;

namespace Training.Repositories.Implementations
{
    public class DistrictRepo : IDistrictRepo
    {
        private readonly ApplicationDbContext _context;

        public DistrictRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Edit(District district)
        {
            _context.Districts.Update(district);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<District>> GetAll()
        {
           var districts = await _context.Districts.Include(x=>x.State).ThenInclude(y=>y.Country).ToListAsync();
           return districts;
        }

        public async Task<District>  GetById(int id)
        {
            var district = await _context.Districts.FindAsync(id);
            return district;
        }

        public async Task RemoveData(District district)
        {
            _context.Districts.Remove(district);
            await _context.SaveChangesAsync();
        }

        public async Task Save(District district)
        {
            await _context.Districts.AddAsync(district);
            await _context.SaveChangesAsync();
        }
    }
}
