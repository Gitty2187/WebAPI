using Entities;

namespace Repositories
{
    public interface IUserRepository
    {
        Task<User> getById(int ID);
        Task<List<User>> GetUsers();
        Task<User> login(string userName, string password);
        Task register(User u);
        Task update(User userToUpdate);
    }
}