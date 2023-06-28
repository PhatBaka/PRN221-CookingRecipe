using DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RecipeModule.Interface
{
    public interface IRecipeService
    {
        public void AddRecipe(Recipe recipe);
    }
}
