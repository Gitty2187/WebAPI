using DTOs;

namespace Services
{
    public interface IUserService
    {
        int checkPassword(string password);
        Task<UserDTO.UserDto> getById(int id);
        Task<List<UserDTO.UserDto>> GetUsers();
        Task<UserDTO.UserDto> login(UserDTO.UserLoginDto userLogin);
        Task register(UserDTO.UserRegisterDto userRegister);
        Task<UserDTO.UserDto> update(UserDTO.UserRegisterDto user, int id);
    }
}