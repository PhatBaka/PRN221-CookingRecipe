using Repository.RecipeDetailModule.Interface;
using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Repository.Utils;

namespace Repository.RecipeDetailModule
{
    public class RecipeDetailRepository : Repository<RecipeDetail>, IRecipeDetailRepository
    {
        private readonly CookingRecipeContext _db;
        public RecipeDetailRepository():base(new CookingRecipeContext())
        {
            _db=new CookingRecipeContext();
        }
        public RecipeDetailRepository(CookingRecipeContext db) : base(db)
        {
            _db = db;
        }

        public ICollection<RecipeDetail> GetRecipeDetailByPostId(int postId) => _db.RecipeDetails.Where(x => x.RecipeId == postId).ToList();

        public int GetMaxID()
        {
            return _db.Recipes.Max(u => u.RecipeId) + 1;
        }
    }
}
