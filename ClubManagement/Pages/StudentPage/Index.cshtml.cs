using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClubManagementRepositories.Models;
using ClubManagementServices.Interfaces;
using ClubManagementServices.ViewModels;

namespace ClubManagement.Pages.StudentPage
{
    public class IndexModel : PageModel
    {
        private readonly IStudentService _studentService;
        public IndexModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public IList<StudentView> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var students = await _studentService.GetAllStudents();
            if(students.Count > 0)
            {
                Student = students;
            }
            else
            {
                TempData["error"] = "There is no student in school!";
            }

        }
    }
}
