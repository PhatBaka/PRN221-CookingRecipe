
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.UserModule.Interface;
using System.Threading.Tasks;

namespace Recipez.Pages.Home
{
    public class ChangePasswordModel : PageModel
    {
        private readonly IUserService _userService;

        public ChangePasswordModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string newPassword, string uid)
        {
            await _userService.ChangePassword(newPassword, uid);
            TempData["success"] = "Password has changed successfully";
            return RedirectToPage("./Index");
        }
    }
}
