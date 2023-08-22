using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ClubManagementRepositories.Models;
using ClubManagementRepositories.Repository;
using Microsoft.EntityFrameworkCore;

namespace ClubManagementTest.RepoTests
{
    public class ClubRepoTests
    {
        private readonly DbContextOptions<ClubManagementContext> _options;

        public ClubRepoTests()
        {
            _options = new DbContextOptionsBuilder<ClubManagementContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        [Fact]
        public async Task AddAsync_ShouldAddClubToDatabase()
        {
            using (var context = new ClubManagementContext(_options))
            {
                var clubRepo = new ClubRepo(context);
                var club = new Club { ClubId = Guid.NewGuid(), ClubName = "Around Club" };

                await clubRepo.AddAsync(club);
                await context.SaveChangesAsync();

                var addedClub = await clubRepo.FindByField(s => s.ClubName == "Around Club");
                Assert.NotNull(addedClub);
                Assert.Equal(club.ClubName, addedClub.ClubName);
            }
        }

        [Fact]
        public async Task FindByField_ShouldRetrieveClubtByExpression()
        {
            using (var context = new ClubManagementContext(_options))
            {
                var clubs = new List<Club>
            {
                new Club { ClubId = Guid.NewGuid(), ClubName = "Best Club Ever" },
                new Club { ClubId = Guid.NewGuid(), ClubName = "Resfesh Club" }
            };
                context.Clubs.AddRange(clubs);
                await context.SaveChangesAsync();

                var clubRepo = new ClubRepo(context);
                var foundClub = await clubRepo.FindByField(s => s.ClubName == "Resfesh Club");

                Assert.NotNull(foundClub);
                Assert.Equal("Resfesh Club", foundClub.ClubName);
            }
        }

        [Fact]
        public async Task FindListByField_ShouldRetrieveListOfClubsByExpression()
        {
            using (var context = new ClubManagementContext(_options))
            {
                var clubs = new List<Club>
            {
                new Club { ClubId = Guid.NewGuid(), ClubName = "Running FPT Club" },
                new Club { ClubId = Guid.NewGuid(), ClubName = "Learning Club" },
                new Club { ClubId = Guid.NewGuid(), ClubName = "FPT Chess Club" }
            };
                context.Clubs.AddRange(clubs);
                await context.SaveChangesAsync();

                var clubRepo = new ClubRepo(context);
                var foundClubs = await clubRepo.FindListByField(s => s.ClubName!.Contains("FPT"));

                Assert.NotNull(foundClubs);
                Assert.Equal(2, foundClubs.Count); // only 2 found
            }
        }

        [Fact]
        public async Task GetAllAsync_ShouldRetrieveAllClubs()
        {
            using (var context = new ClubManagementContext(_options))
            {
                var clubs = new List<Club>
            {
                new Club { ClubId = Guid.NewGuid(), ClubName = "John Doe" },
                new Club { ClubId = Guid.NewGuid(), ClubName = "Jane Smith" },
            };
                context.Clubs.AddRange(clubs);
                await context.SaveChangesAsync();

                var clubRepo = new ClubRepo(context);
                var allClubs = await clubRepo.GetAllAsync();

                Assert.NotNull(allClubs);
                Assert.Equal(2, allClubs.Count);
            }
        }

        [Fact]
        public async Task Remove_ShouldRemoveClubFromDatabase()
        {
            using (var context = new ClubManagementContext(_options))
            {
                var club = new Club { ClubId = Guid.NewGuid(), ClubName = "Test Remove", IsDeleted = false };
                context.Clubs.Add(club);
                await context.SaveChangesAsync();

                var clubRepo = new ClubRepo(context);
                club.IsDeleted = true;
                clubRepo.Remove(club);
                await context.SaveChangesAsync();

                var removedClub = await context.Clubs.FindAsync(club.ClubId);
                Assert.NotNull(removedClub);
                Assert.True(removedClub.IsDeleted);
            }
        }

        [Fact]
        public async Task Update_ShouldUpdateClubFromDatabase()
        {
            using (var context = new ClubManagementContext(_options))
            {
                var club = new Club { ClubId = Guid.NewGuid(), ClubName = "Test Update" };
                context.Clubs.Add(club);
                await context.SaveChangesAsync();

                var clubRepo = new ClubRepo(context);
                club.ClubName = "Club Name has updated";
                clubRepo.Update(club);
                await context.SaveChangesAsync();

                var updatedClub = await context.Clubs.FindAsync(club.ClubId);
                Assert.NotNull(updatedClub);
                Assert.Equal("Club Name has updated", updatedClub.ClubName);
            }
        }
    }
}
