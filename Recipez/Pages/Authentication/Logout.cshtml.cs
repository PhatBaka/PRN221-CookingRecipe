using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Repository.Pages.Authentication
{
    [IgnoreAntiforgeryToken]
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            if(User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync();
                return RedirectToPage("/Home/Index");
            }
            return Forbid();
        }
    }
}
