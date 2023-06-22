using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Recipez.Pages.Flower
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly DataAccess.Models.FUFlowerBouquetManagementContext _context;

        public DetailsModel(DataAccess.Models.FUFlowerBouquetManagementContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
