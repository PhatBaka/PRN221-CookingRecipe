using Repository.UserModule.Interface;
using DataAccess.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Repository.Pages.Authentication
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly IConfiguration Configuration;
        private readonly IUserService _userService;
        public Customer? admin { get; private set; }

        public IndexModel(IConfiguration configuration,IUserService userService)
        {
            Configuration = configuration;
            _userService = userService;
        }

        public string email { get; set; }
        public string password { get; set; }
        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                TempData["noti"] = "You have already logged in";
                return RedirectToPage("/Home/Index");
            }

            return Page();
        }
        public async Task<IActionResult> OnPost(string email, string password)
        {
            admin = Configuration.GetSection("admin").Get<Customer>();
            //Login with username and password -> check if it is admin
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                //check user
                if (email == admin.Email && password == admin.Password)
                {
                    var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Email, admin.Email),
                            new Claim(ClaimTypes.NameIdentifier, "0"),
                            new Claim(ClaimTypes.Role, RoleEnum.Admin.ToString())
                        };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    TempData["success"] = "Welcome Admin";
                    return RedirectToPage("/Index");
                }
                else
                {
                    var User = await _userService.Authenticate(email, password);
                    if (User != null)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Email, User.Email),
                            new Claim(ClaimTypes.NameIdentifier, User.CustomerId.ToString()),
                            new Claim(ClaimTypes.Role, RoleEnum.Customer.ToString())
                        };
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(claimsPrincipal);
                        TempData["success"] = "Welcome " + User.CustomerName;
                        return RedirectToPage("/Home/Index");
                    }
                    else
                    {
                        TempData["error"] = "Invalid credentials, please try again later!";
                        return Page();
                    }
                }
                
            }
            else
            {
                TempData["error"] = "Empty field(s) detected, please try again";
                return Page();
            }
        }
    }
}
