using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DTOs;
using AutoMapper;
using static DTOs.CategoryDTO;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepositories _productRepositories;
        private readonly IMapper _mapper;


        public ProductService(IProductRepositories productRepositories, IMapper mapper)
        {
            _productRepositories = productRepositories;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> GetAll()
        {
            List<Product> products = await _productRepositories.GetAll();
            List<ProductDTO> productsDTOs = _mapper.Map<List<Product>, List<ProductDTO>>(products);
            return productsDTOs;
        }

        public async Task<ProductDTO> getById(int id)
        {
            if (id == null)
                throw new Exception("Must insert id");
            Product product = await _productRepositories.getById(id);
            ProductDTO productDTO = _mapper.Map<Product, ProductDTO>(product);
            return productDTO;
        }
    }
}
