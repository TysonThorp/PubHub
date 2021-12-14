using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IUserDao
    {
        User GetUser(string username);
        User GetUser(int userId);
        User AddUser(string username, string password, string role);
        User UpdateUser(int UserId, User user);
        List<User> GetAllUsers();
    }
}
