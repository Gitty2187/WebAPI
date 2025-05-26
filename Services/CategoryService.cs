using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DTOs;
using Entities;
using Repositories;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDTO>> GetAll()
        {
            List<Category> categories = await _categoryRepository.GetAll();
            List<CategoryDTO> categoryDTOs = _mapper.Map<List<Category>, List<CategoryDTO>>(categories);
            return categoryDTOs;
        }
    }
}
