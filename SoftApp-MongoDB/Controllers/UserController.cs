using Microsoft.AspNetCore.Mvc;
using SoftApp_MongoDB.Models;
using SoftApp_MongoDB.Services;

namespace SoftApp_MongoDB.Controllers
{
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {
        //private readonly UserServiceMongoDB _userService;

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet(nameof(GetAllUser))]
        public List<User> GetAllUser()
        {
            return _userService.GetUsers();
        }
        [HttpGet(nameof(GetAllUser2))]

        public List<User> GetAllUser2()
        {
            return _userService.Collections();
        }

        [HttpPost(nameof(InsertUser))]

        public void InsertUser([FromBody] User user)
        {
            _userService.InsertUser(user);
        }

        [HttpPost(nameof(UpdateUser))]
        public User UpdateUser([FromBody] User user)
        {
            return _userService.UpdateUser(user);
        }

        [HttpPost(nameof(DeleteEntity))]
        public bool DeleteEntity([FromBody] User user)
        {
            var result = _userService.DeleteEntity(user);
            return result;
        }

        [HttpPost(nameof(InsertUserList))]
        public void InsertUserList([FromBody] List<User> users)
        {
            _userService.InsertList(users);
        }
    }
}
