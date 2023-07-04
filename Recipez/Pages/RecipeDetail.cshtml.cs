using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Recipez.Pages
{
    public class RecipeDetailModel : PageModel
    {
        private readonly RecipezService recipezService;
        [BindProperty]
        public Recipe recipe { get; set; }
        [BindProperty]
        public List<RecipeDetail> recipeDetails { get; set; }
        [BindProperty]
        public List<Step> steps { get; set; }
        public RecipeDetailModel()
        {
            recipezService = new RecipezService();
        }
        public IActionResult OnGet(int ?id)
        {
            if (id==null)
            {
                return NotFound();
            }
            recipe = recipezService.recipeService.GetRecipeByID((int)id);
            recipeDetails = recipezService.recipeDetailService.GetRecipeDetailByPostId((int)id).ToList();
            foreach (RecipeDetail recipeDetail in recipeDetails)
            {
                recipeDetail.Ingredient=recipezService.ingredientService.GetIngredientById(recipeDetail.IngredientId);
            }
            steps = recipezService.stepService.GetStepByRecipeId((int)id).ToList();
            return Page();
        }
    }
}
