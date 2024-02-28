using AutoMapper;
using Customers.API.Dto;
using Customers.API.Models;

namespace Customers.API.Helpers
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles() {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
