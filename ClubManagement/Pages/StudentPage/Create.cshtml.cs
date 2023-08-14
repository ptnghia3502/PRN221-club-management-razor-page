using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClubManagementRepositories.Models;
using ClubManagementServices.Interfaces;
using ClubManagementServices.ViewModels;

namespace ClubManagement.Pages.StudentPage
{
    public class CreateModel : PageModel
    {
        private readonly IStudentService _studentService;
        private readonly IMajorService _majorService;
        private readonly IGradeService _gradeService;

        public CreateModel(IStudentService studentService ,IMajorService majorService, IGradeService gradeService)
        {
            _studentService=studentService;
            _majorService = majorService;
            _gradeService = gradeService;
        }

        public async Task<IActionResult> OnGet()
        {
            ViewData["GradeId"] = new SelectList(await _gradeService.GetAllGrade(), "GradeId", "GradeName");
            ViewData["MajorId"] = new SelectList(await _majorService.GetAllMajor(), "MajorId", "MajorName");
            return Page();
        }

        [BindProperty]
        public StudentCreateView Student { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            await _studentService.CreateStudent(Student);
            return RedirectToPage("./Index");
        }
    }
}
