using CookingBakery.Utils;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Recipez.Pages
{
    public class ListRecipeModel : PageModel
    {
        private readonly RecipezService recipezService;
        private readonly int PAGESIZE = 6;
        public PaginatedList<Recipe> paging { get; set; }
        [BindProperty]
        public int PageIndex { get; set; }
        public ListRecipeModel()
        {
            recipezService = new RecipezService();            
        }
        public void OnGet(int? id)
        {            
            if (id == null)
            {
                PageIndex = 1;
            }
            else
            {
                PageIndex = id.Value;
            }
            List<Recipe> recipes = (List<Recipe>)recipezService.recipeService.GetAll();
            paging = PaginatedList<Recipe>.Create(recipes.AsQueryable<Recipe>(),PageIndex,PAGESIZE);
        }
    }
}
