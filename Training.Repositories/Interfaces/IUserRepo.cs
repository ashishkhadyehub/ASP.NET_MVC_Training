using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Models;

namespace Training.Repositories.Interfaces
{
    public interface IUserRepo
    {
        Task RegisterUser(UserInfo userInfo);

        Task<UserInfo> GetUserInfo(string username, string password);
    }
}
