using Customers.API.Dto;
using Customers.API.Models;

namespace Customers.UnitTests.Fixtures
{
    public static class UsersFixture
    {
        public static List<User> GetTestUsers() => new() {
        new()
                {
                    Id= 1,
                    Name= "Pablo",                   
                    Street="Charcas",
                    City ="Caba",
                    State= "Caba",
                    Dni =27535991,
                    Email = "pablo.martinez7908@gmail.com",
                    Phone = "4-165165131",
                    Mobile = "11-64752716"
                },
        new()
                {
                    Id= 2,
                    Name= "Mia",                   
                    Street="Charcas",
                    City ="Caba",
                    State= "Caba",
                    Dni =27535992,
                    Email = "Mia.martinez@gmail.com",
                    Phone = "4-165165131",
                    Mobile = "11-64752716"
                },
        new()
                {
                    Id= 3,
                    Name= "Ava",
                    Street="Charcas",
                    City ="Caba",
                    State= "Caba",
                    Dni =27535993,
                    Email = "Ava.martinez@gmail.com",
                    Phone = "4-165165131",
                    Mobile = "11-64752716"
                }
        };
    }           
}
