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
using static DTOs.ProductDTO;

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

        public async Task<List<ProductDto>> GetAll()
        {
            List<Product> products = await _productRepositories.GetAll();
            return _mapper.Map<List<Product>, List<ProductDto>>(products);
           
        }

        public async Task<ProductDto> getById(int id)//GetById
        {
            if (id == null)
                throw new Exception("Must insert id");
            Product product = await _productRepositories.getById(id);
            ProductDto productDTO = _mapper.Map<Product, ProductDto>(product);//return ....
            return productDTO;
        }
    }
}
