using EMS.Repository.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Repository.Implementations
{
    public class UtilityRepo : IUtilityRepo
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _contextAccessor;

        public UtilityRepo(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor contextAccessor)
        {
            _webHostEnvironment = webHostEnvironment;
            _contextAccessor = contextAccessor;
        }

        public Task DeleteImage(string foldername, string dbpath)
        {
            if (string.IsNullOrEmpty(dbpath))
            {
                return Task.CompletedTask;
            }
            var filename = Path.GetFileName(dbpath);
            var completepath = Path.Combine(_webHostEnvironment.WebRootPath, foldername, filename);
            if (File.Exists(completepath))
            {
                File.Delete(completepath);
            }
            return Task.CompletedTask;
        }

        public async Task<string> EditImage(string foldername, IFormFile file, string dbpath)
        {
            await DeleteImage(foldername, dbpath);
            return await SaveImage(foldername, file);
        }

        public async Task<string> SaveImage(string foldername, IFormFile file)
        {

            var extension = Path.GetExtension(file.FileName);
            var filename = $"{Guid.NewGuid()}{extension}";
            string folder = Path.Combine(_webHostEnvironment.WebRootPath, foldername);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string filepath = Path.Combine(folder, filename);
            using (var memorystream = new MemoryStream())
            {
                await file.CopyToAsync(memorystream);
                var content = memorystream.ToArray();
                await File.WriteAllBytesAsync(filepath, content);
            }

            var basepath = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}";
            var completepath = Path.Combine(basepath, foldername, filename).Replace("\\", "/");
            return completepath;


        }
    }
}
