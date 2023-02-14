using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.InMemory;
using MedAdvisor.DataAccess.MySql;
using MedAdvisor.Models;
using System.Threading.Tasks;
using Xunit;
using MedAdvisor.Models.Models;
using MedAdvisor.DataAccess.MySql.Repositories;
using Microsoft.Identity.Client;

namespace MedAdvisor.API.Test.RepositoryTests
{
    public class UserDiagnosisRepositroytest
    {
        private async Task<MedTrackerContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<MedTrackerContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new MedTrackerContext(options);
            databaseContext.Database.EnsureCreated();
            if (await databaseContext.Users.CountAsync() <= 0)
            {
                for (int i = 1; i <= 10; i++)
                {
                    databaseContext.Users.Add(
                    new User()
                    {
                        Id = i,
                        Email = "Henok@gmail.com",
                        FirstName = "Henok",
                        LastName = "Matheas"

                    });
                    await databaseContext.SaveChangesAsync();
                }
            }

            if (await databaseContext.Diagnosis.CountAsync() <= 0)
            {
                for (int i = 1; i <= 10; i++)
                {
                    databaseContext.Diagnosis.Add(
                    new Diagnosis()
                    {
                        Id = i,
                        Name = "Cholera, unspecified",

                        Code = "A009",
                    });
                    await databaseContext.SaveChangesAsync();
                }
            }
            if (await databaseContext.UserDiagnoses.CountAsync() <= 0)
            {
                for (int i = 1; i <= 10; i++)
                {
                    databaseContext.UserDiagnoses.Add(
                    new UserDiagnosis()
                    {
                        UserId = i,
                        DiagnosisId = i,
            
                    });
                    await databaseContext.SaveChangesAsync();
                }
            }

            return databaseContext;
        }

        [Fact]
        public async void UserDiagnosisRepository_GetUserDiagnoses_ReturnsListOfDiagnosis()
        {
            var id = 1;
            var dbContext = await GetDatabaseContext();
            var repo = new UserDiagnosisRepository(dbContext);

            var result = repo.GetUserDiagnoses(id);

            result.Should().NotBeNull();
            result.Should().BeOfType<List<Diagnosis>>();
        }

        [Fact]
        public async void UserDiagnosisRepository_AddDiagnosis_ReturnsBool()
        {
            int userId = 2;
            int diagosisId = 1;
            var dbContext = await GetDatabaseContext();
            var repo = new UserDiagnosisRepository(dbContext);
            var result = repo.AddDiagnosis(userId, diagosisId);
            result.Should().BeTrue();

        }

        // [Fact]
        // public async void UserDiagnosisRepository_RemoveDiagnoses_ReturnsBool()
        // {
        //     int userId = 2;
        //     var diagnoses = new List<int>() {1};
        //     var dbContext = await GetDatabaseContext();
        //     var repo = new UserDiagnosisRepository(dbContext);
        //     var result = repo.RemoveDiagnoses(userId, diagnoses);
        //     result.Should().BeTrue();

        // }

    }
}