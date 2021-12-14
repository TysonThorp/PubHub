using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Capstone.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserDao userDao;
        public UsersController(IUserDao _userDao)
        {
            userDao = _userDao;
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult GetAllUsers()
        {
            List<User> listOfUsers = userDao.GetAllUsers();
            if (listOfUsers != null)
            {
                return Ok(listOfUsers);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult AddUser(string username, string password, string role)
        {
            
            User result = userDao.AddUser(username, password, role);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("{userName}")]
        [Authorize(Roles = "admin")]
        public IActionResult GetUserByName(string username)
        {
            User user = userDao.GetUser(username);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{userId}")]
        public IActionResult UpdateUser(int UserId, User user)
        {
            User userToUpdate = userDao.GetUser(UserId);
            if (userToUpdate != null)
            {
                userDao.UpdateUser(UserId, user);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
