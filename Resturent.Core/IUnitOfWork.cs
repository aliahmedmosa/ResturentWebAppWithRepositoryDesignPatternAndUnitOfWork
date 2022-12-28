using Resturent.Core.Models;
using Resturent.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturent.Core
{
    public interface IUnitOfWork:IDisposable
    {
        IBaseRepository<Category> Categories { get; }
        IMealsRepository Meals { get; }
        

        int Complete();
    }
}
