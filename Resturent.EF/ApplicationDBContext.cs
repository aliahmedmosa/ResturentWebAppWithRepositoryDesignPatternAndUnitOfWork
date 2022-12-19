using Microsoft.EntityFrameworkCore;
using Resturent.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturent.EF
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Meal> Meals { get; set; }
    }
}
