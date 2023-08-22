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

            CreateMap<ClubView, Club>().ReverseMap();
            CreateMap<Club, ClubCreateView>()
                //.ForMember(dest=>dest.ChairmanEmail,act=>act.Ignore())
                .ReverseMap();
            CreateMap<Club, ClubUpdateView>()
                .ForMember(dest => dest.LogoImage, act => act.Ignore())               
                .ReverseMap();

            CreateMap<ClubBoardView, ClubBoard>().ReverseMap();
            CreateMap<ClubBoardCreateView,ClubBoard>().ReverseMap();
            CreateMap<ClubBoardUpdateView, ClubBoard>().ReverseMap();

            CreateMap<MembershipView,Membership>().ReverseMap();

            CreateMap<MemberClubBoardView, MemberClubBoard>().ReverseMap();

            CreateMap<MemberOption,Membership>()
                .ForPath(x=>x.Student!.StudentName, op=>op.MapFrom(src=>src.StudentName))
                .ReverseMap();

            CreateMap<ClubActivityCreateView,ClubActivity>().ReverseMap();
            CreateMap<ClubActivityUpdateView, ClubActivity>().ReverseMap();

            CreateMap<Participant, ParticipantView>()
                .ForMember(dest => dest.MemberName, act => act.Ignore())
                .ForMember(dest => dest.ActivityName, act => act.Ignore())
                .ReverseMap();

            CreateMap<ParticipantCreateView,Participant>().ReverseMap();
            CreateMap<ParticipantUpdateView,Participant>().ReverseMap();
        }
    }
}
