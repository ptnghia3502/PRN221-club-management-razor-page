using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubManagementRepositories.Interfaces;
using ClubManagementRepositories.Models;

namespace ClubManagementServices
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ClubManagementContext _dbContext;

        private readonly IStudentRepo _studentRepository;
        private readonly IParticipantRepo _participantRepository;
        private readonly IMembershipRepo _membershipRepository;
        private readonly IMemberClubBoardRepo _memberClubBoardRepository;
        private readonly IMajorRepo _majorRepository;
        private readonly IGradeRepo _gradeRepository;
        private readonly IClubRepo _clubRepository;
        private readonly IClubBoardRepo _clubBoardRepository;
        private readonly IClubActivityRepo _clubActivityRepository;

        public UnitOfWork(ClubManagementContext dbContext, IStudentRepo studentRepository,
            IParticipantRepo participantRepository,
            IMembershipRepo membershipRepository, IMemberClubBoardRepo memberClubBoardRepository
            , IMajorRepo majorRepository
            , IGradeRepo gradeRepository,
            IClubRepo clubRepository,
            IClubBoardRepo clubBoardRepository,
            IClubActivityRepo clubActivityRepository)
        {
            _dbContext = dbContext;
            _studentRepository = studentRepository;
            _participantRepository = participantRepository;
            _membershipRepository = membershipRepository;
            _memberClubBoardRepository = memberClubBoardRepository;
            _majorRepository = majorRepository;
            _gradeRepository = gradeRepository;
            _clubRepository = clubRepository;
            _clubBoardRepository = clubBoardRepository;
            _clubActivityRepository = clubActivityRepository;
        }

        public IStudentRepo StudentRepository => _studentRepository;

        public IParticipantRepo ParticipantRepository => _participantRepository;

        public IMembershipRepo MembershipRepository => _membershipRepository;

        public IMemberClubBoardRepo MembershipClubBoardRepository => _memberClubBoardRepository;

        public IMajorRepo MajorRepository => _majorRepository;

        public IGradeRepo GradeRepository => _gradeRepository;

        public IClubRepo ClubRepository => _clubRepository;

        public IClubBoardRepo ClubBoardRepository => _clubBoardRepository;

        public IClubActivityRepo ClubActivityRepository => _clubActivityRepository;

        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
