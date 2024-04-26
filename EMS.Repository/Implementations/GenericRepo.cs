using EMS.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Repository.Implementations
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Edit(T model)
        {
            _context.Set<T>().Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task RemoveData(T model)
        {
            _context.Set<T>().Remove(model);
            await _context.SaveChangesAsync();  
        }

        public async Task Save(T model)
        {
            await _context.Set<T>().AddAsync(model);
            await  _context.SaveChangesAsync();
        }
    }
}
