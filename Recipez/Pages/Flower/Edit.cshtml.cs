using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Recipez.Pages.Flower
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly DataAccess.Models.FUFlowerBouquetManagementContext _context;

        public EditModel(DataAccess.Models.FUFlowerBouquetManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FlowerBouquet FlowerBouquet { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FlowerBouquet = await _context.FlowerBouquets
                .Include(f => f.Category)
                .Include(f => f.Supplier).FirstOrDefaultAsync(m => m.FlowerBouquetId == id);

            if (FlowerBouquet == null)
            {
                return NotFound();
            }
           ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
           ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FlowerBouquet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlowerBouquetExists(FlowerBouquet.FlowerBouquetId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FlowerBouquetExists(int id)
        {
            return _context.FlowerBouquets.Any(e => e.FlowerBouquetId == id);
        }
    }
}
