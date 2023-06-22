using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Recipez.Pages.Customer
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly DataAccess.Models.FUFlowerBouquetManagementContext _context;

        public CreateModel(DataAccess.Models.FUFlowerBouquetManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DataAccess.Models.Customer Customer { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
