using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClubManagementRepositories.Models;
using ClubManagementServices.Interfaces;
using ClubManagementServices.ViewModels;

namespace ClubManagement.Pages.StudentPage
{
    public class EditModel : PageModel
    {
        private readonly IStudentService _studentService;
        private readonly IMajorService _majorService;
        private readonly IGradeService _gradeService;
        public EditModel(IStudentService studentService, IMajorService majorService, IGradeService gradeService)
        {
            _studentService = studentService;
            _majorService = majorService;
            _gradeService = gradeService;
        }

        [BindProperty]
        public StudentUpdateView Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            
            Student = await _studentService.GetUpdateInfor(id!.Value);
            if(Student == null)
            {
                return NotFound();
            }
            ViewData["GradeId"] = new SelectList(await _gradeService.GetAllGrade(), "GradeId", "GradeName");
            ViewData["MajorId"] = new SelectList(await _majorService.GetAllMajor(), "MajorId", "MajorName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _studentService.Update(Student);

            return RedirectToPage("./Index");
        }

        
    }
}
