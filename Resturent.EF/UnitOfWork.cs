using Resturent.Core;
using Resturent.Core.Models;
using Resturent.Core.Repositories;
using Resturent.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturent.EF
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationDBContext _Context;

        public IBaseRepository<Category> Categories { get; private set; }
        public IBaseRepository<Meal> Meals { get; private set; }
        public UnitOfWork( ApplicationDBContext context)
        {
            _Context = context;
            Categories = new BaseRepository<Category>(_Context);
            Meals = new BaseRepository<Meal>(_Context);
        }
        public int Complete()
        {
            return _Context.SaveChanges();
        }

        public void Dispose()
        {
            _Context.Dispose();
        }
    }
}
