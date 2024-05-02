using EMS.Models;
using EMS.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Repository.Implementations
{
    public class AdminRepo : IAdminRepo
    {
        private readonly ApplicationDbContext _context;

        public AdminRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<IEnumerable<LeaveApplication>> GetAllApplications()
        {
            return await _context.LeaveApplications.Include(x=>x.Employee).ToListAsync();
        }

        public async Task<LeaveApplication> GetById(int id)
        {
            return await _context.LeaveApplications.Include(x => x.Employee).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateApplication(int id, string status)
        {
            var app = await _context.LeaveApplications.FindAsync(id);
            app.Status = status;
            await _context.SaveChangesAsync();
        }
    }
}
