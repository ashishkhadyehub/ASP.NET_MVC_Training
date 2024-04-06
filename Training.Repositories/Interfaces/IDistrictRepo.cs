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
        IEnumerable<District> GetAll();

        District GetById(int id);

        void Save(District district);

        void Edit(District district);

        void RemoveData(District district);
    }
}
