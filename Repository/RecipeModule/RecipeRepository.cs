using Repository.RecipeModule.Interface;
using DataAccess.Models;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using Repository.Utils;

namespace Repository.RecipeModule
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        private readonly CookingRecipeContext _db;
        public RecipeRepository():base(new CookingRecipeContext())
        {
            _db = new CookingRecipeContext();
        }
        public RecipeRepository(CookingRecipeContext db) : base(db)
        {
            _db = db;
        }
        public ICollection<Recipe> GetPostsBy(Expression<Func<Recipe, bool>> filter = null,
            Func<IQueryable<Recipe>, ICollection<Recipe>> options = null,
            string includeProperties = null)
        {
            IQueryable<Recipe> query = DbSet;

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
            return _db.Recipes.Max(u => u.RecipeId) + 1;
        }
    }
}
