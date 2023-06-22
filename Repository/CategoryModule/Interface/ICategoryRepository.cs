using DataAccess.Models;
using Repository.Utils.BakeryRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.CategoryModule.Interface
{
    public interface ICategoryRepository : IRepository<Category>
    {
        public ICollection<Category> GetCategoriesBy(
            Expression<Func<Category, bool>> filter = null,
            Func<IQueryable<Category>, ICollection<Category>> options = null,
            string includeProperties = null
        );
        public int GetMaxID();
    }
}
