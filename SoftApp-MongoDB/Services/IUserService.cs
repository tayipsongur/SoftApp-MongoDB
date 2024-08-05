using Microsoft.AspNetCore.Mvc;
using SoftApp_MongoDB.Models;

namespace SoftApp_MongoDB.Services
{
    public interface IUserService
    {
        List<User> GetUsers();
        List<User> Collections();
        void InsertUser(User user);
        User UpdateUser(User user);
        void InsertList([FromBody] List<User> users);
    }
}
