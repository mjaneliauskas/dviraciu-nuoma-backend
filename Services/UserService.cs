using dviraciu_nuoma_backend.Models;
using dviraciu_nuoma_backend.Repository;

namespace dviraciu_nuoma_backend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public List<UserModel>? GetAll()
        {
            return _userRepository.GetAll().ToList();
        }

        public UserModel? GetUserByUsername(string username)
        {
            return _userRepository.Get(user => user.PrisijungimoVardas.Equals(username)).FirstOrDefault();
        }

        public UserModel? GetUserByUsernamePassword(string username, string password)
        {
            var user = _userRepository.Get(user => user.PrisijungimoVardas.Equals(username) && user.Slaptazodis.Equals(password)).FirstOrDefault();
            return user;
        }
    }

    public interface IUserService
    {
        List<UserModel>? GetAll();
        UserModel? GetUserByUsername(string username);
        UserModel? GetUserByUsernamePassword(string username, string password);
    }
}
