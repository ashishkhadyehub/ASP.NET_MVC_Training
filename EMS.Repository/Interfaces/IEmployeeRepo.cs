using EMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Repository.Interfaces
{
    public interface IEmployeeRepo
    {
        Task RegisterEmployee(Employee employee);

        Task UpdateEmployee(Employee employee);

        Task<Employee> GetUserInfo(string email, string password);

        Task<Employee> GetById(int id);

        Task SubmitApplication(LeaveApplication application);
        Task<IEnumerable<LeaveApplication>> GetApplications(int id);
    }
}
