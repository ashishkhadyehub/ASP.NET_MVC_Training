
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.FirstApp.Models;

namespace Training.FirstApp.Data
{
    //ApplicationDbContext-derived class
    //DbContext- base class


    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
    }
}
