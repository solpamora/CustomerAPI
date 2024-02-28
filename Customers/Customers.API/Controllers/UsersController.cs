
using AutoMapper;
using Customers.API.Dto;
using Customers.API.Interfaces.Repository;
using Customers.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Customers.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;

    public UsersController(IUsersRepository usersRepository,IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }

    [HttpGet(Name = "GetAllUsers")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
    public IActionResult GetAllUsers()
    {
        var users = _mapper.Map<List<UserDto>>(_usersRepository.GetAllUsers());

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(users);

    }

    [HttpGet("{userId}")]
    [ProducesResponseType(200, Type = typeof(User))]
    [ProducesResponseType(400)]
    public IActionResult GetUser(int userId)
    {
        if (!_usersRepository.UserExists(userId))
            return NotFound();

        var user = _mapper.Map<UserDto>(_usersRepository.GetUser(userId));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(user);
    }

    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(409)]
    public IActionResult CreateUser( [FromBody] UserDto userCreate)
    {
        if (userCreate == null)
            return BadRequest(ModelState);

        if (_usersRepository.EmailExists(userCreate.Email))
        {
            ModelState.AddModelError("", "Email Exists");
            return StatusCode(409, ModelState);
        }

        if (_usersRepository.DniExists(userCreate.Dni))
        {
            ModelState.AddModelError("", "Dni Exists");
            return StatusCode(409, ModelState);
        }


        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var userMap = _mapper.Map<User>(userCreate);

       
        if (!_usersRepository.CreateUser(userMap))
        {
            ModelState.AddModelError("", "Something went wrong while saving");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully created");
    }

    [HttpPut]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    [ProducesResponseType(409)]
    public IActionResult UpdateUser([FromBody] UserDto updatedUser)
    {
        if (updatedUser == null)
            return BadRequest(ModelState);

        

        if (!_usersRepository.UserExists(updatedUser.Id))
            return NotFound();

        if (_usersRepository.EmailExists(updatedUser.Email, updatedUser.Id))
        {
            ModelState.AddModelError("", "Email Exists");
            return StatusCode(409, ModelState);
        }

        if (_usersRepository.DniExists(updatedUser.Dni, updatedUser.Id))
        {
            ModelState.AddModelError("", "Dni Exists");
            return StatusCode(409, ModelState);
        }

        if (!ModelState.IsValid)
            return BadRequest();

        var userMap = _mapper.Map<User>(updatedUser);

        if (!_usersRepository.UpdateUser(userMap))
        {
            ModelState.AddModelError("", "Something went wrong updating owner");
            return StatusCode(500, ModelState);
        }

        return NoContent();
    }

    [HttpDelete("{userId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteUser(int userId)
    {
        if (!_usersRepository.UserExists(userId))
        {
            return NotFound();
        }

        var userToDelete = _usersRepository.GetUser(userId);
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
       

        if (!_usersRepository.DeleteUser(userToDelete))
        {
            ModelState.AddModelError("", "Something went wrong deleting owner");
        }

        return NoContent();
    }

}
