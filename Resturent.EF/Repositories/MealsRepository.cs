using Microsoft.EntityFrameworkCore;
using Resturent.Core.Models;
using Resturent.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturent.EF.Repositories
{
    public class MealsRepository : BaseRepository<Meal>, IMealsRepository
    {
        private readonly ApplicationDBContext _Context;
        public MealsRepository(ApplicationDBContext Context):base(Context)
        {
           _Context=Context;
        }
        public IEnumerable<Meal> GetMeals()
        {
            return _Context.Meals.Include(x=>x.category).ToList();
        }
    }
}
