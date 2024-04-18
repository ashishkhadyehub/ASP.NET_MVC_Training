using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Models;

namespace Training.Repositories.Interfaces
{
    public interface IDistrictRepo
    {
        Task<IEnumerable<District>> GetAll();

        Task<District> GetById(int id);

        Task Save(District district);

        Task Edit(District district);

        Task RemoveData(District district);
    }
}
