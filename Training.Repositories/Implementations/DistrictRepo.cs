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

        public void Edit(District district)
        {
            _context.Districts.Update(district);
            _context.SaveChanges();
        }

        public IEnumerable<District> GetAll()
        {
           var districts = _context.Districts.Include(x=>x.State).ThenInclude(y=>y.Country).ToList();
           return districts;
        }

        public District GetById(int id)
        {
            var district = _context.Districts.Find(id);
            return district;
        }

        public void RemoveData(District district)
        {
            _context.Districts.Remove(district);
            _context.SaveChanges();
        }

        public void Save(District district)
        {
            _context.Districts.Add(district);
            _context.SaveChanges();
        }
    }
}
