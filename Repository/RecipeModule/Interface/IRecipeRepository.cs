using DataAccess.Models;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System;
using Repository.Utils.Interface;

namespace Repository.RecipeModule.Interface
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        public ICollection<Recipe> GetPostsBy(
            Expression<Func<Recipe, bool>> filter = null,
            Func<IQueryable<Recipe>, ICollection<Recipe>> options = null,
            string includeProperties = null
        );
        public int GetMaxID();
    }
}
