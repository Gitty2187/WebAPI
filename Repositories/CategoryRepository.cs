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
        PetsShop_DBContext dBContext;//_dBContext

        public CategoryRepository(PetsShop_DBContext context)
        {
            dBContext = context;
        }


        public async Task<List<Category>> GetAll()
        {
            try
            {
                return await dBContext.Categories.Include(i => i.Products).ToListAsync<Category>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
