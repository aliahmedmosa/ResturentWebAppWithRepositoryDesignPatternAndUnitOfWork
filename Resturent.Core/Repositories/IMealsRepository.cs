using Resturent.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturent.Core.Repositories
{
    public interface IMealsRepository:IBaseRepository<Meal>
    {
        IEnumerable<Meal> GetMealsIncludeCategory();
    }
}
