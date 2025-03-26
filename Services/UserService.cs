using PetsShop;
using Repositories;

namespace Services
{
    
    public class UserService
    {
        UserRepository repository = new UserRepository();
        public User login(String userName, String password, string firstName)
        {
            return repository.login(userName, password);
    
        }
        public User register(String userName, String password, string name, string lastName)
        {
            return repository.register(userName, password, name, lastName);
        }
    }
}
