using ClubManagementRepositories.Interfaces;
using ClubManagementServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClubManagement.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IStudentService _studentService;

        public IndexModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public void OnGet()
        {
            HttpContext.Session.Clear();
        }

        public async Task<IActionResult> OnPost(string email, string studentCardId)
        {
            if (email == null || studentCardId == null)
            {
                return Page();
            }
            var account = await _studentService.LoginAsync(email, studentCardId);
            if (account == null)
            {
                TempData["error"] = "Account is not exist or wrong password";
                return Page();
            }
            if (account != null && email.Equals("admin@gmail.com"))
            {
                HttpContext.Session.SetString("isAdmin", "true");
                HttpContext.Session.SetString("isLogin", "true");
                return RedirectToPage("./AdminMainPage");
            } else
            {
                HttpContext.Session.SetString("isAdmin", "false");
                HttpContext.Session.SetString("isLogin", "true");
                HttpContext.Session.SetString("studentId", account!.StudentId.ToString());
                return RedirectToPage("./StudentMainPage");
            }
            
        }
    }
}