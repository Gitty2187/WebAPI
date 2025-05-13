using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        PetsShop_DBContext dBContext;

        public UserRepository(PetsShop_DBContext context)
        {
            dBContext = context;
        }

        public async Task<User> login(String userName, String password)
        {
            try
            {
                return await dBContext.Users.FirstAsync(user => user.UserName == userName && user.Password == password);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task register(User u)
        {
            try
            {
                //if (await dBContext.Users.AnyAsync(user => user.UserName == u.UserName && user.Password == u.Password) == null)
                //    throw new HttpStatusException(409, "User already exist");
                await dBContext.Users.AddAsync(u);
                await dBContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task update(User userToUpdate)
        {
            try
            {
                dBContext.Users.Update(userToUpdate);
                await dBContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<User> getById(int ID)
        {
            try
            {
                return await dBContext.Users.FirstOrDefaultAsync(user => user.Id == ID);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<List<User>> GetUsers()
        {
            try
            {
                return await dBContext.Users.ToListAsync<User>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
