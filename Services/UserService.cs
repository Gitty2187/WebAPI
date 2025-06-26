using Microsoft.VisualBasic;
using Entities;
using Repositories;
using System.Xml.Linq;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Metadata;
using AutoMapper;
using DTOs;
using static DTOs.UserDTO;

namespace Services
{
    public class UserService : IUserService

    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> login(UserLoginDto userLogin)//Login
        {
            if (userLogin.UserName == null || userLogin.Password == null)
                return null;
            UserLogin userLogin1 = _mapper.Map<UserLoginDto, UserLogin>(userLogin);//clean code - Writing names with meaning
            User user = await _userRepository.login(userLogin1);
            return _mapper.Map<User, UserDto>(user);
        }

        public async Task register(UserRegisterDto userRegister)//Register
        {
            if (userRegister.UserName == null || userRegister.Password == null)
                throw new Exception("Must insert userName & password");
            if (checkPassword(userRegister.Password) < 2)
                throw new Exception("Must insert more hard password");
            User userToRegister = _mapper.Map<UserRegisterDto, User>(userRegister);
            await _userRepository.register(userToRegister);
        }

        public async Task<UserDto> update(UserRegisterDto user, int id)//Update
        {
            if (user.UserName == null || user.Password == null)
                throw new Exception("Must insert userName & password");
            if (checkPassword(user.Password) <= 2)
                throw new Exception("Must insert more hard password");
            User userToUpdate = _mapper.Map<UserRegisterDto, User>(user);
            userToUpdate.Id = id;
            User UpdateUser = await _userRepository.update(userToUpdate, id);//clean code - Writing variables with a lowercase letter
            // if (UpdateUser != null)
            //     return _mapper.Map<User, UserDto>(UpdateUser);
            // return null;
            return _mapper.Map<User, UserDto>(UpdateUser);//if UpdateUser is null, it will return null

        }

        public int checkPassword(string password)//CheckPassword
        {
            if (password != null)
            {
                var zxcvbnResult = Zxcvbn.Core.EvaluatePassword(password);
                return zxcvbnResult.Score;

            }
            return -1;
        }

        public async Task<List<UserDto>> GetUsers()
        {
            List<User> users = await _userRepository.GetUsers();
            return _mapper.Map<List<User>, List<UserDto>>(users);
        }

        public async Task<UserDto> getById(int id)//GetById
        {
            if (id == null)
                throw new Exception("Must insert id");
            User user = await _userRepository.getById(id);
            return _mapper.Map<User, UserDto>(user);
        }
    }
}
