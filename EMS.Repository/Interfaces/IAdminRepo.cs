using EMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Repository.Interfaces
{
    public interface IAdminRepo
    {
        Task<IEnumerable<Employee>> GetAll();

        Task<IEnumerable<LeaveApplication>> GetAllApplications();

        Task UpdateApplication(int id, string status);

        Task<LeaveApplication> GetById(int id);
    }
}
