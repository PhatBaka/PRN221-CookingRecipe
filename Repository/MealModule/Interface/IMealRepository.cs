using DataAccess.Models;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System;
using Repository.Utils.Interface;

namespace Repository.MealModule.Interface
{
    public interface IMealRepository : IRepository<Meal>
    {
        public ICollection<Meal> GetPostsBy(
            Expression<Func<Meal, bool>> filter = null,
            Func<IQueryable<Meal>, ICollection<Meal>> options = null,
            string includeProperties = null
        );
        public int GetMaxID();
    }
}
