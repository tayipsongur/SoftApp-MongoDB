using Microsoft.AspNetCore.Mvc;
using SoftApp.MongoDB.Repository;
using SoftApp_MongoDB.Models;
using System.Text.Json.Serialization;

namespace SoftApp_MongoDB.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoRepository<User> _userRepository;
        public UserService(IServiceProvider serviceProvider)
        {
            _userRepository = serviceProvider.GetRequiredService<IMongoRepository<User>>();
        }

        public List<User> GetUsers()
        {
            var userList = _userRepository.GetAllEntities();
            return userList.AsQueryable().ToList();
        }

        public List<User> Collections()
        {
            var userList = _userRepository.Collection.AsQueryable().ToList();
            return userList;
        }

        public void InsertUser(User user)
        {
            _userRepository.Insert(user);
        }

        public User UpdateUser(User user)
        {
            var updatedUser = _userRepository.Update(user);
            return updatedUser;
        }

        public void InsertList([FromBody] List<User> users)
        {
            try
            {
                _userRepository.Insert(users);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message.ToString());
            }
        }
    }
}
