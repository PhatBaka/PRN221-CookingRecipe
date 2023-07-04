using DataAccess.Models;
using Repository.IngredientCategoryModule.Interface;
using Repository.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IngredientCategoryModule
{
    public class IngredientCategoryRepository:Repository<IngredientCategory>,IIngredientCategoryRepository
    {
        private readonly CookingRecipeContext context;

        public IngredientCategoryRepository():base(new CookingRecipeContext())
        {
            context = new CookingRecipeContext();
        }
        public IngredientCategoryRepository(CookingRecipeContext db) : base(db)
        {
            context = db;
        }
    }
}
