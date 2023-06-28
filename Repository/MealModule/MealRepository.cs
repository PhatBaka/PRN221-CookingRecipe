using Repository.MealModule.Interface;
using DataAccess.Models;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using Repository.Utils;

namespace Repository.MealModule
{
    public class MealRepository : Repository<Meal>, IMealRepository
    {
        private readonly CookingRecipeContext _db;

        public MealRepository(CookingRecipeContext db) : base(db)
        {
            _db = db;
        }
        public ICollection<Meal> GetPostsBy(Expression<Func<Meal, bool>> filter = null,
            Func<IQueryable<Meal>, ICollection<Meal>> options = null,
            string includeProperties = null)
        {
            IQueryable<Meal> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return options != null ? options(query).ToList() : query.ToList();
        }

        public int GetMaxID()
        {
            return _db.Meals.Max(u => u.MealId) + 1;
        }
    }
}
