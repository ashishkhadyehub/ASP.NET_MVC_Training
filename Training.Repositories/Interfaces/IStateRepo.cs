using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Models;

namespace Training.Repositories.Interfaces
{
    public interface IStateRepo
    {
        IEnumerable<State> GetAll();

        State GetById(int id);

        void Save(State state);

        void Edit(State state);

        void RemoveData(State state);
    }
}
