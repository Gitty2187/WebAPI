using AutoMapper;
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

        public async Task<User> login(UserLogin userLogin)
        {
            try
            {
                return await dBContext.Users.FirstAsync(user => user.UserName == userLogin.UserName && user.Password == userLogin.Password);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task register(User user)
        {

            try
            {
                //if (await dBContext.Users.AnyAsync(user => user.UserName == u.UserName && user.Password == u.Password) == null)
                //    throw new HttpStatusException(409, "User already exist");
                await dBContext.Users.AddAsync(user);
                await dBContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<User> update(User userToUpdate, int id)
        {
            try
            {
                dBContext.Users.Update(userToUpdate);
                await dBContext.SaveChangesAsync();
                return userToUpdate;
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
