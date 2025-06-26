using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using DTOs;
using static DTOs.OrderDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860//

namespace PetsShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

               //clean code writing meaningful function names

        // POST api/<OrdersController>//
        [HttpPost]
        public async Task<ActionResult<OrderDto>> Post([FromBody] OrderDto order)
        {
            try
            {
                await _orderService.Add(order);
                return Ok(order);
            }
            catch
            {
                return BadRequest();
            }
        }

     
    }
}
