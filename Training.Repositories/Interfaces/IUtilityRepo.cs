using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Repositories.Interfaces
{
    public interface IUtilityRepo
    {
        Task<string> SaveImage(string foldername,IFormFile file);

        Task<string> EditImage(string foldername,IFormFile file, string dbpath);

        Task DeleteImage(string foldername, string dbpath);


    }
}
