using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        PetsShop_DBContext dBContext;

        public CategoryRepository(PetsShop_DBContext context)
        {
            dBContext = context;
        }

        public async Task<Category> getById(int ID)
        
        {
            try
            {
                return await dBContext.Categories.FirstOrDefaultAsync(c => c.Id == ID);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<List<Category>> GetAll()
        {
            try
            {
                return await dBContext.Categories.ToListAsync<Category>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
