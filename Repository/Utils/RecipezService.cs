using Repository.IngredientCategoryModule;
using Repository.IngredientCategoryModule.Interface;
using Repository.IngredientModule;
using Repository.IngredientModule.Interface;
using Repository.RecipeDetailModule;
using Repository.RecipeDetailModule.Interface;
using Repository.RecipeModule;
using Repository.RecipeModule.Interface;
using Repository.StepModule;
using Repository.StepModule.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Utils
{
    public class RecipezService
    {
        public IRecipeService recipeService { get; }
        public IRecipeDetailService recipeDetailService { get; }
        public IIngredientCategoryService ingredientCategoryService { get; }
        public IIngredientService ingredientService { get; }
        public IStepService stepService { get; }
        public RecipezService()
        {
            recipeService = new RecipeService();
            recipeDetailService = new RecipeDetailService();
            ingredientCategoryService = new IngredientCategoryService();
            ingredientService=new IngredientService();
            stepService = new StepService();
        }
    }
}
