using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubManagementRepositories.Interfaces;

namespace ClubManagementServices
{
    public interface IUnitOfWork
    {
        public IStudentRepo StudentRepository { get; }
        public IParticipantRepo ParticipantRepository { get; }
        public IMembershipRepo MembershipRepository { get; }
        public IMemberClubBoardRepo MembershipClubBoardRepository { get; }
        public IMajorRepo MajorRepository { get; }
        public IGradeRepo GradeRepository { get; }
        public IClubRepo ClubRepository { get; }
        public IClubBoardRepo ClubBoardRepository { get; }
        public IClubActivityRepo ClubActivityRepository { get; }
        public Task<int> SaveChangeAsync();
    }
}
