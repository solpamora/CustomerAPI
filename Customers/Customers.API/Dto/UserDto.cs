using Customers.API.Models;
using System.ComponentModel.DataAnnotations;

namespace Customers.API.Dto
{
    public class UserDto
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public long Dni { get; set; }
            public string Street { get; set; }
            public string State { get; set; }
            public string City { get; set; }
            public string Phone { get; set; }
            public string Mobile { get; set; }
            public string Email { get; set; }

    }
}
