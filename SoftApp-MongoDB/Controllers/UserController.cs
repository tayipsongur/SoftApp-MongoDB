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
            try
            {
                return _userService.GetUsers();

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet(nameof(GetAllUser2))]

        public List<User> GetAllUser2()
        {
            try
            {
                return _userService.Collections();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost(nameof(InsertUser))]

        public void InsertUser([FromBody]User user)
        {
            try
            {
                _userService.InsertUser(user);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost(nameof(InsertUserList))]
        public void InsertUserList([FromBody]List<User> users)
        {
            try
            {
                _userService.InsertList(users);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
