using DataAccess.DataModels;
using Repository.RecipeDetailModule.Interface;
using Repository.Utils.BakeryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RecipeDetailModule
{
    public class RecipeDetailRepository : Repository<RecipeDetail>, IRecipeDetailRepository
    {
        private readonly CookingRecipeContext context;
        public RecipeDetailRepository(CookingRecipeContext db) : base(db)
        {
            context=db;
        }
    }
}
