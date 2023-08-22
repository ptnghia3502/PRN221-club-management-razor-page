using ClubManagementRepositories.Models;
using ClubManagementServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagementServices.Interfaces
{
    public interface IClubActivityService
    {
        Task<List<ClubActivity>> GetAllActivitiesByClubId(Guid clubId);
        Task<bool> CreateActivity(ClubActivityCreateView createView);

        Task<ClubActivity> GetActivityById(Guid id);
        Task<ClubActivityUpdateView> GetActivityUpdateViewById(Guid id);
        Task<bool> UpdateActivity(ClubActivityUpdateView updateView);
        Task<bool> Delete(Guid id);

    }
}
