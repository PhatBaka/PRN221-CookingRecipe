using CookingBakery.Utils;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.PostModule.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipez.Pages.Home
{
    public class Index : PageModel
    {
        private readonly FUFlowerBouquetManagementContext _context;
        private readonly IFlowerService _flowerService;
        public Index(IFlowerService flowerService, FUFlowerBouquetManagementContext context)
        {
            _flowerService = flowerService;
            _context = context;
        }

        public PaginatedList<FlowerBouquet> Post { get; set; }
        public IEnumerable<FlowerBouquet> NewestPost { get; set; }
        public string SearchName { get; set; }
        public int? CategoryId { get; set; }

        public void OnGetAsync(
            string currentSearchName, string txtSearchName,
            int? currentFilterCategory, int? filterCategory,
            int? pageIndex
        )
        {
            NewestPost = _flowerService.GetNewestPosts(4);

            if (txtSearchName != null || filterCategory != null)
            {
                pageIndex = 1;
            }
            else
            {
                txtSearchName = currentSearchName;
                filterCategory = currentFilterCategory;
            }

            var posts = _flowerService.GetAll().AsQueryable();

            if (!string.IsNullOrEmpty(txtSearchName))
            {
                SearchName = txtSearchName;
                posts = posts.Where(o => o.FlowerBouquetName.ToLower().Contains(txtSearchName.ToLower()));
            }

            if (filterCategory != null)
            {
                CategoryId = (int)filterCategory;
                posts = posts.Where(o => o.FlowerBouquetId == filterCategory);
            }

            Post = PaginatedList<FlowerBouquet>.Create(posts, pageIndex ?? 1, 5);

            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
        }

    }
}