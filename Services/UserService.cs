using Microsoft.VisualBasic;
using Entities;
using Repositories;
using System.Xml.Linq;


namespace Services
{
    public class UserService : IUserService

    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> login(string UserName, string password)
        {
            if (UserName == null || password == null)
                return null;
            return await _userRepository.login(UserName, password);
        }

        public async Task register(User user)
        {
            if (checkPassword(user.Password) < 2)
                throw new Exception("Must insert more hard password");
            if (user.UserName == null || user.Password == null)
                throw new Exception("Must insert userName & password");
            await _userRepository.register(user);
        }

        public async Task update(User user)
        {
            if (user.UserName == null || user.Password == null)
                throw new Exception("Must insert userName & password");
            await _userRepository.update(user);
            return;
        }

        public int checkPassword(string password)
        {
            if (password != null)
            {
                var zxcvbnResult = Zxcvbn.Core.EvaluatePassword(password);
                return zxcvbnResult.Score;

            }
            return -1;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _userRepository.GetUsers();
        }

        public async Task<User> getById(int id)
        {
            if (id == null)
                throw new Exception("Must insert id");
            return await _userRepository.getById(id);
        }
    }
}
