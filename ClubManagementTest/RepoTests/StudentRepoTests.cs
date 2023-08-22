using AutoMapper;
using ClubManagementServices.Service;
using ClubManagementServices.ViewModels;
using ClubManagementServices;
using Moq;
using Microsoft.AspNetCore.Http;
using ClubManagementRepositories.Models;
using ClubManagementRepositories.Repository;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ClubManagementRepositories.Interfaces;

namespace ClubManagementTest.RepoTests
{
    public class StudentRepoTests
    {
        private readonly DbContextOptions<ClubManagementContext> _options;

        public StudentRepoTests()
        {
            _options = new DbContextOptionsBuilder<ClubManagementContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        [Fact]
        public async Task AddAsync_ShouldAddStudentToDatabase()
        {
            using (var context = new ClubManagementContext(_options))
            {
                var studentRepo = new StudentRepo(context);
                var student = new Student { StudentId = Guid.NewGuid(), StudentName = "Nghia Pham" };

                await studentRepo.AddAsync(student);
                await context.SaveChangesAsync();

                var addedStudent = await studentRepo.FindByField(s => s.StudentName == "Nghia Pham");
                Assert.NotNull(addedStudent);
                Assert.Equal(student.StudentName, addedStudent.StudentName);
            }
        }

        [Fact]
        public async Task FindByField_ShouldRetrieveStudentByExpression()
        {
            using (var context = new ClubManagementContext(_options))
            {
                var students = new List<Student>
            {
                new Student { StudentId = Guid.NewGuid(), StudentName = "Ngoc Thy" },
                new Student { StudentId = Guid.NewGuid(), StudentName = "Xuan Quang" }
            };
                context.Students.AddRange(students);
                await context.SaveChangesAsync();

                var studentRepo = new StudentRepo(context);
                var foundStudent = await studentRepo.FindByField(s => s.StudentName == "Ngoc Thy");

                Assert.NotNull(foundStudent);
                Assert.Equal("Ngoc Thy", foundStudent.StudentName);
            }
        }

        [Fact]
        public async Task FindListByField_ShouldRetrieveListOfStudentsByExpression()
        {
            using (var context = new ClubManagementContext(_options))
            {
                var students = new List<Student>
            {
                new Student { StudentId = Guid.NewGuid(), StudentName = "Trong Nghia" },
                new Student { StudentId = Guid.NewGuid(), StudentName = "Minh Quang" },
                new Student { StudentId = Guid.NewGuid(), StudentName = "Minh Hieu" }
            };
                context.Students.AddRange(students);
                await context.SaveChangesAsync();

                var studentRepo = new StudentRepo(context);
                var foundStudents = await studentRepo.FindListByField(s => s.StudentName.Contains("Nghia"));

                Assert.NotNull(foundStudents);
                Assert.Equal(1, foundStudents.Count); // only 1 found
            }
        }

        [Fact]
        public async Task GetAllAsync_ShouldRetrieveAllStudents()
        {
            using (var context = new ClubManagementContext(_options))
            {
                var students = new List<Student>
            {
                new Student { StudentId = Guid.NewGuid(), StudentName = "John Doe" },
                new Student { StudentId = Guid.NewGuid(), StudentName = "Jane Smith" },
            };
                context.Students.AddRange(students);
                await context.SaveChangesAsync();

                var studentRepo = new StudentRepo(context);
                var allStudents = await studentRepo.GetAllAsync();

                Assert.NotNull(allStudents);
                Assert.Equal(2, allStudents.Count);
            }
        }

        [Fact]
        public async Task Remove_ShouldRemoveStudentFromDatabase()
        {
            using (var context = new ClubManagementContext(_options))
            {
                var student = new Student { StudentId = Guid.NewGuid(), StudentName = "Test Remove", IsDeleted = false };
                context.Students.Add(student);
                await context.SaveChangesAsync();

                var studentRepo = new StudentRepo(context);
                student.IsDeleted = true;
                studentRepo.Remove(student);
                await context.SaveChangesAsync();

                var removedStudent = await context.Students.FindAsync(student.StudentId);
                Assert.NotNull(removedStudent);
                Assert.True(removedStudent.IsDeleted);
            }
        }

        [Fact]
        public async Task Update_ShouldUpdateStudentFromDatabase()
        {
            using (var context = new ClubManagementContext(_options))
            {
                var student = new Student { StudentId = Guid.NewGuid(), StudentName = "Test Update" };
                context.Students.Add(student);
                await context.SaveChangesAsync();

                var studentRepo = new StudentRepo(context);
                student.StudentName = "Student Name has updated";
                studentRepo.Update(student);
                await context.SaveChangesAsync();

                var updatedStudent = await context.Students.FindAsync(student.StudentId);
                Assert.NotNull(updatedStudent);
                Assert.Equal("Student Name has updated", updatedStudent.StudentName);
            }
        }
    }
}