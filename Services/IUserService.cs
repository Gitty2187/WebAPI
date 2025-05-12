using Entities;

namespace Services
{
    public interface IUserService
    {
        int checkPassword(string password);
        Task<User> getById(int id);
        Task<List<User>> GetUsers();
        Task<User> login(string userName, string password);
        Task register(User user);
        Task update(User user);
    }
}