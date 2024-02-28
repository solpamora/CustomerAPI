using AutoMapper;
using FakeItEasy;
using Customers.API.Controllers;
using Customers.API.Interfaces.Repository;
using Customers.UnitTests.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Customers.API.Dto;
using Customers.API.Models;

namespace Customers.UnitTests.Systems.Controllers;

public class TestUsersController
{
    private readonly IUsersRepository _usersRepository;  
    private readonly IMapper _mapper;

    public TestUsersController()
    {
        _usersRepository = A.Fake<IUsersRepository>();      
        _mapper = A.Fake<IMapper>();
    }

    [Fact]
    public void PokemonController_GetUsers_ReturnOK()
    {
        //Arrange
        var users = A.Fake<ICollection<UserDto>>();
        var usersList = A.Fake<List<UserDto>>();
        A.CallTo(() => _mapper.Map<List<UserDto>>(users)).Returns(usersList);
        var controller = new UsersController(_usersRepository, _mapper);

        //Act
        var result = controller.GetAllUsers();

        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkObjectResult));
    }

    [Fact]
    public void UsersController_CreateUser_ReturnOK()
    {
        //Arrange
        var userMap = A.Fake<User>();
        var user = A.Fake<User>();
        var userCreate = A.Fake<UserDto>();
        var users = A.Fake<ICollection<UserDto>>();
        var userList = A.Fake<IList<UserDto>>();       
        A.CallTo(() => _mapper.Map<User>(userCreate)).Returns(user);
        A.CallTo(() => _usersRepository.CreateUser(userMap)).Returns(true);
        var controller = new UsersController(_usersRepository, _mapper);

        //Act
        var result = controller.CreateUser(userCreate);

        //Assert
        result.Should().NotBeNull();
    }





}