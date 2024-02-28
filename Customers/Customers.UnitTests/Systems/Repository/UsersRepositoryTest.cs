using Customers.API.DataBaseContext;
using Customers.API.Repository;
using Customers.UnitTests.Fixtures;
using Microsoft.EntityFrameworkCore;
using Xunit;
using FluentAssertions;
using Customers.API.Models;

namespace Customers.UnitTests.Systems.Repository
{
    public class UsersRepositoryTest
    {
        private async Task<MyDataBaseContext> GetDataBaseContext()
        {
            var options = new DbContextOptionsBuilder<MyDataBaseContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var databaseContext = new MyDataBaseContext(options);
            databaseContext.Database.EnsureCreated();
            

            if (databaseContext.Users.Count() <= 0 ) 
            {
                var listusers = UsersFixture.GetTestUsers();

                databaseContext.Users.AddRange(listusers);
                databaseContext.SaveChanges();
              
            }

            return databaseContext;
        }

        [Fact]
        public async void UsersRepository_GetUser_ReturnsUser()
        {
            //Arrange
            var id = 1;
            var dbContext = await GetDataBaseContext();
            var usersRepository = new UsersRepository(dbContext);

            //Act
            var result = usersRepository.GetUser(id);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<User>();
        }

        [Fact]
        public async void UsersRepository_GetUsers_ReturnAllUsers()
        {
            //Arrange           
            var dbContext = await GetDataBaseContext();
            var usersRepository = new UsersRepository(dbContext);

            //Act
            var result = usersRepository.GetAllUsers();

            //Assert
            result.Should().NotBeNull();
            result.Count().Should().Be(3);
        }

        [Fact]
        public async void UsersRepository_UpdateUser_ReturnSuccess()
        {
            //Arrange           
            var dbContext = await GetDataBaseContext();
            var usersRepository = new UsersRepository(dbContext);
            User    user = new User()
            {
                Id = 1,
                Name = "Pablo Daniel",
                Street = "Charcas",
                City = "Caba",
                State = "Caba",
                Dni = 27535991,
                Email = "pablo.martinez7908@gmail.com",
                Phone = "4-165165131",
                Mobile = "11-64752716"
            };
            //Act
            var result = usersRepository.UpdateUser(user);

            //Assert
            Assert.True(result);

        }
    }
}
