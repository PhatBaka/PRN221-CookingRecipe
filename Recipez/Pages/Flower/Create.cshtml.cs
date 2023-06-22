using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.Models;
using Repository.PostModule.Interface;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Recipez.Pages.Flower
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly DataAccess.Models.FUFlowerBouquetManagementContext _context;
        private readonly IFlowerService _flowerService;

        public CreateModel(DataAccess.Models.FUFlowerBouquetManagementContext context, IFlowerService flowerService)
        {
            _context = context;
            _flowerService = flowerService;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
        ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierId");
            return Page();
        }

        [BindProperty]
        public FlowerBouquet FlowerBouquet { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            FlowerBouquet.FlowerBouquetStatus = 1;
             _flowerService.AddNewPost(FlowerBouquet);

            return RedirectToPage("./Index");
        }
    }
}
