using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClubManagement.Pages
{
    public class StudentMainPageModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
