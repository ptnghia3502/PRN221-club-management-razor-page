using AutoMapper;
using ClubManagementRepositories.Models;
using ClubManagementServices.ViewModels;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagementServices.Mappers
{
    public class MapperConfigurationsProfile:Profile
    {
        public MapperConfigurationsProfile()
        {
            CreateMap<StudentView, Student>().ReverseMap();
            CreateMap<StudentCreateView, Student>().ReverseMap();
            CreateMap<Student, StudentUpdateView>()
                .ForMember(dest => dest.Avatar, act => act.Ignore())
                .ReverseMap();
        }
    }
}
