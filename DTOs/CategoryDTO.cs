using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class CategoryDTO
    {
        public record CategoryDto(int Id, string Name, ICollection<Product> Products);
    }
}
