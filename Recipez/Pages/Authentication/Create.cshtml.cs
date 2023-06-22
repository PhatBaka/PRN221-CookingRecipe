using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Repository.UserModule.Interface;
using DataAccess.Models;
using Repository.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Repository.Pages.Authentication
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IConfiguration Configuration;
        private readonly IUserService _userService;
        private readonly FUFlowerBouquetManagementContext _context;
        public Customer? admin { get; private set; }
        public CreateModel(IConfiguration configuration, IUserService userService, FUFlowerBouquetManagementContext context)
        {
            Configuration = configuration;
            _userService = userService;
            _context = context;
        }

        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                TempData["noti"] = "You have already logged in";
                return RedirectToPage("/Home/Index");
            }

            return Page();
        }

        [BindProperty] public Customer NewUser { get; set; }

        public async Task<IActionResult> OnPost()
        {
            admin = Configuration.GetSection("admin").Get<Customer>();
            if (string.IsNullOrEmpty(NewUser.Email) && string.IsNullOrEmpty(NewUser.Password) && string.IsNullOrEmpty(NewUser.CustomerName)
                && string.IsNullOrEmpty(NewUser.City)
                && string.IsNullOrEmpty(NewUser.Country)
                && NewUser.Birthday + "" == "")
            {
                TempData["error"] = "Fill the fields below";
                return Page();
            }

            if(NewUser.Email == admin.Email)
            {
                TempData["error"] = "Email existed, please sign up with another email";
                return Page();
            }

            await _userService.AddNewUser(NewUser);
            TempData["noti"] = "Account created";
            return RedirectToPage("/Authentication/Index");

        }
    }
}