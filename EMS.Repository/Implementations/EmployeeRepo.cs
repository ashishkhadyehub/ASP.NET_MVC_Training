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
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LeaveApplication>> GetApplications(int id)
        {
            var applications = await _context.LeaveApplications.Where(x => x.EmployeeId == id).ToListAsync();
            return applications;
        }

        public async Task<Employee> GetById(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<Employee> GetUserInfo(string email, string password)
        {
            var user = await _context.Employees.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower() && x.Password == password);
            return user;
        }

        public async Task RegisterEmployee(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task SubmitApplication(LeaveApplication application)
        {
            await _context.LeaveApplications.AddAsync(application);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }
    }
}
