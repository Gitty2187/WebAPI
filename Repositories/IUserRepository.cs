using Entities;

namespace Repositories
{
    public interface IUserRepository
    {
        Task<User> getById(int ID);
        Task<List<User>> GetUsers();
        Task<User> login(UserLogin userLogin);
        Task register(User user);
        Task<User> update(User userToUpdate, int id);
    }
}