using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        PetsShop_DBContext dBContext;//_dBContext

        public OrderRepository(PetsShop_DBContext context)
        {
            dBContext = context;
        }

        public async Task<Order> getById(int ID)//GetById
        {
            try
            {
                return await dBContext.Orders.Include(i=>i.OrderItems).FirstOrDefaultAsync(c => c.Id == ID);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<List<Order>> GetAll()
        {
            try
            {
                return await dBContext.Orders.Include(i => i.OrderItems).ToListAsync<Order>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task Add(Order order)
        {
            try
            {
                await dBContext.Orders.AddAsync(order);
                await dBContext.SaveChangesAsync();
                //return order;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
