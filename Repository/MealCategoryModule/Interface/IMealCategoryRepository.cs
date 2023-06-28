using DataAccess.Models;
using Repository.Utils.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.MealCategoryModule.Interface
{
    public interface IMealCategoryRepository : IRepository<MealCategory>
    {
        public ICollection<MealCategory> GetCategoriesBy(
            Expression<Func<MealCategory, bool>> filter = null,
            Func<IQueryable<MealCategory>, ICollection<MealCategory>> options = null,
            string includeProperties = null
        );
        public int GetMaxID();
    }
}
