using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.Models;
using Repository.ProductModule.Interface;

namespace Recipez.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly DataAccess.Models.FUFlowerBouquetManagementContext _context;
        private readonly IProductService _productService;

        public CreateModel(DataAccess.Models.FUFlowerBouquetManagementContext context,IProductService productService)
        {
            _productService = productService;
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "City");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _productService.AddNewProduct(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
