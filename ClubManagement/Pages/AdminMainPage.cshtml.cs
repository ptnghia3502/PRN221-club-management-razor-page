using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClubManagement.Pages
{
    public class AdminMainPageModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
