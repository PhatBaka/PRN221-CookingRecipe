
using DataAccess.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.UserModule.Interface;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Recipez.Pages.Home
{
    public class UserProfile : PageModel
    {
        private readonly IUserService _userService;

        private readonly FUFlowerBouquetManagementContext _context;


        private readonly IWebHostEnvironment _env;

        public UserProfile(IUserService userService, FUFlowerBouquetManagementContext context)
        {
            _userService = userService;
            _context = context;
        }

        [BindProperty]
        public DataAccess.Models.Customer user { get; set; }

        public void OnGet()
        {
            user = _userService.GetUserByUserID(int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value));
        }

        public async Task<IActionResult> OnPostAsync(IFormFile customFile)
        {
            if (customFile != null)
            {

            }
            await _userService.UpdateUser(user);
            TempData["success"] = "Profile has been updated successfully";
            return Page();
        }
    }
}
