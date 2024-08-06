using Microsoft.AspNetCore.Mvc;
using SoftApp.MongoDB.Repository;
using SoftApp_MongoDB.Models;

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
        public bool DeleteEntity(User user)
        {
            var result = _userRepository.Delete(user);
            return result;
        }

        public void InsertList([FromBody] List<User> users)
        {
            _userRepository.Insert(users);
        }
    }
}
