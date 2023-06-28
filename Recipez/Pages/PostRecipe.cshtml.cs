using DataAccess.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.IngredientCategoryModule.Interface;
using Repository.RecipeModule.Interface;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Recipez.Pages
{
    public class PostRecipeModel : PageModel
    {
        [BindProperty]
        public Recipe recipe { get; set; }
        [BindProperty]
        public string listIngredientID { get; set; }
        [BindProperty]
        public string listStepID { get; set; }
        public IList<IngredientCategory> ingredientCategories { get; set; }

        private readonly IRecipeService recipeService;
        private readonly IIngredientCategoryService ingredientCategoryService;
        public PostRecipeModel(IRecipeService _recipeService, IIngredientCategoryService service)
        {
            recipeService = _recipeService;
            ingredientCategoryService = service;
        }        
        public void OnGet()
        {
            ingredientCategories= ingredientCategoryService.GetAll().ToList();
            ViewData["Categories"] = new SelectList(ingredientCategories, "CategoryId", "CategoryName");
        }
        public IActionResult OnPost()
        {
            List<Ingredient> ingredients;
            string[] ingredientID=listIngredientID.Split(",");
            foreach(var id in ingredientID)
            {

            }
            List<Step> steps;
            recipeService.AddRecipe(recipe);
            return RedirectToPage("./Home");
        }
    }
}
