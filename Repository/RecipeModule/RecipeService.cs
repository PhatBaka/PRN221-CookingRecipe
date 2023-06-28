using DataAccess.DataModels;
using Repository.RecipeModule.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RecipeModule
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository recipeRepository;        
        public RecipeService(IRecipeRepository _recipeRepository)
        {
            this.recipeRepository = _recipeRepository;            
        }
        public void AddRecipe(Recipe recipe)
        {
            recipe.RecipeId=recipeRepository.GetMaxID();
            recipeRepository.Add(recipe);
        }
    }
}
