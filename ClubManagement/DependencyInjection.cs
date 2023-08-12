using ClubManagementRepositories.Interfaces;
using ClubManagementRepositories.Models;
using ClubManagementRepositories.Repository;
using ClubManagementServices;
using ClubManagementServices.Interfaces;
using ClubManagementServices.Mappers;
using ClubManagementServices.Service;

namespace ClubManagement
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(ClubManagementContext));
            #region DI_Repository
            services.AddScoped<IClubActivityRepo, ClubActivityRepo>();
            services.AddScoped<IClubBoardRepo, ClubBoardRepo>();
            services.AddScoped<IClubRepo, ClubRepo>();
            services.AddScoped<IGradeRepo, GradeRepo>();
            services.AddScoped<IMajorRepo, MajorRepo>();
            services.AddScoped<IMemberClubBoardRepo, MemberClubBoardRepo>();
            services.AddScoped<IMembershipRepo, MembershipRepo>();
            services.AddScoped<IParticipantRepo, ParticipantRepo>();
            services.AddScoped<IStudentRepo, StudentRepo>();
            #endregion

            #region DI_Service
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped<IClubActivityService, ClubActivityService>();
            services.AddScoped<IClubBoardService, ClubBoardService>();
            services.AddScoped<IClubService, ClubService>();
            services.AddScoped<IGradeService, GradeService>();
            services.AddScoped<IMajorService, MajorService>();
            services.AddScoped<IMemberClubBoardService, MemberClubBoardService>();
            services.AddScoped<IMembershipService, MembershipService>();
            services.AddScoped<IParticipantService, ParticipantService>();
            services.AddScoped<IStudentService, StudentService>();
            #endregion

            services.AddAutoMapper(typeof(MapperConfigurationsProfile).Assembly);
            return services;
        }
    }
}
