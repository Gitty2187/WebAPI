using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DTOs.OrderItemDTO;

namespace DTOs
{
    public class OrderDTO
    {
        public record OrderDto(int Id, DateTime? Date, int? Sum, int? UserId, ICollection<OrderItemDto> Products);
    }
}
