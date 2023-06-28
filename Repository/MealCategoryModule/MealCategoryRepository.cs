using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Repository.MealCategoryModule.Interface;
using Repository.Utils;

namespace Repository.MealCategoryModule
{
    public class MealCategoryRepository : Repository<MealCategory>, IMealCategoryRepository
    {
        private readonly CookingRecipeContext _db;

        public MealCategoryRepository(CookingRecipeContext db) : base(db)
        {
            _db = db;
        }
        public ICollection<MealCategory> GetCategoriesBy(
            Expression<Func<MealCategory, bool>> filter = null,
            Func<IQueryable<MealCategory>, ICollection<MealCategory>> options = null,
            string includeProperties = null
        )
        {
            IQueryable<MealCategory> query = DbSet;

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
            return _db.MealCategories.Max(u => u.MealCategoryId) + 1;
        }
    }
}
