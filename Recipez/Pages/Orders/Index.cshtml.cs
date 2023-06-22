using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;

namespace Recipez.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly DataAccess.Models.FUFlowerBouquetManagementContext _context;

        public IndexModel(DataAccess.Models.FUFlowerBouquetManagementContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }

        public async Task OnGetAsync()
        {
            Order = await _context.Orders
                .Include(o => o.Customer).ToListAsync();
        }
    }
}
