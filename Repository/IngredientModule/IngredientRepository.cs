using DataAccess.DataModels;
using Repository.IngredientModule.Interface;
using Repository.Utils.BakeryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IngredientModule
{
    public class IngredientRepository:Repository<Ingredient>,IIngredientRepository
    {
        private readonly CookingRecipeContext context;

        public IngredientRepository(CookingRecipeContext db) : base(db)
        {
            context = db;
        }
    }
}
