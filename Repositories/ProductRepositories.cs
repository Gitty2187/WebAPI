using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepositories : IProductRepositories
    {
        PetsShop_DBContext dBContext;//_dBContext

        public ProductRepositories(PetsShop_DBContext context)
        {
            dBContext = context;
        }

        public async Task<List<Product>> GetAll()
        {
            try
            {
                return await dBContext.Products.ToListAsync<Product>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Product> getById(int ID)//GetById
        {
            try
            {
                return await dBContext.Products.FirstOrDefaultAsync(p => p.Id == ID);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
