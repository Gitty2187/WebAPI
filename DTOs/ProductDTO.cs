using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ProductDTO
    {
        public record ProductDto(int Id, string Name, int? Price, int? CategoryId,string CategoryName, string Description, string ImageURL);
    }
}
