using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClubManagementRepositories.Models;
using ClubManagementServices.Common;
using ClubManagementServices.Interfaces;
using ClubManagementServices.ViewModels;

namespace ClubManagementServices.Service
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public StudentService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateStudent(StudentCreateView createDTO)
        {
            var fileName = createDTO.StudentCardId + "_" + createDTO.StudentName;
            var newStudent = _mapper.Map<Student>(createDTO);
            var file = await createDTO.Avatar!.UploadFileAsync(fileName);
            if(file != null)
            {
                newStudent.AvatarName = file.FileName;
                newStudent.AvatarUrl = file.URL;
                newStudent.CreateAt=DateTime.Now;
            }
            await _unitOfWork.StudentRepository.AddAsync(newStudent);          

            return await _unitOfWork.SaveChangeAsync()>0;
        }

        public async Task<List<StudentView>> GetAllStudents()
        {
            var students= await _unitOfWork.StudentRepository.GetAllAsync(x=>x.Major!,x=>x.Grade!);
            var result= _mapper.Map<List<StudentView>>(students);
            return result;
        }

        public async Task<StudentView> GetStudentById(Guid id)
        {
            var student= await _unitOfWork.StudentRepository.FindByField(x=>x.StudentId==id,x=>x.Major!,x=>x.Grade!);
            var result= _mapper.Map<StudentView>(student);
            return result;
        }

        public async Task<StudentUpdateView> GetUpdateInfor(Guid id)
        {

            var student = await _unitOfWork.StudentRepository.FindByField(x => x.StudentId == id, x => x.Major!, x => x.Grade!);
            var result = _mapper.Map<StudentUpdateView>(student);
            return result;
        }

        public async Task<bool> Update(StudentUpdateView updateDTO)
        {
            var student = await _unitOfWork.StudentRepository.FindByField(x => x.StudentId == updateDTO.StudentId);
            string fileName = string.Empty;
            if (student == null)
            {
                return false;
            }
            if (updateDTO.Avatar != null)
            {
                if (!string.IsNullOrEmpty(student.AvatarName))
                {
                    await student.AvatarName!.RemoveFileAsync();
                }
                fileName = updateDTO.StudentCardId + "_" + updateDTO.StudentName;
                var upload = await updateDTO.Avatar!.UploadFileAsync(fileName);
                if (upload != null)
                {
                    student.AvatarName = fileName;
                    student.AvatarUrl = upload.URL;
                }
            }
            student = _mapper.Map(updateDTO, student);
            student.AvatarName = fileName;
            _unitOfWork.StudentRepository.Update(student);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }
}
