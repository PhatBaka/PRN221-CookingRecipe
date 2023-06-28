using DataAccess.DataModels;
using Repository.RecipeModule.Interface;
using Repository.Utils.BakeryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RecipeModule
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        private readonly CookingRecipeContext context;
        public RecipeRepository(CookingRecipeContext db) : base(db)
        {
            context = db;
        }
        public int GetMaxID()
        {
            return context.Recipes.Max(r=>r.RecipeId)+1;
        }
    }
}
