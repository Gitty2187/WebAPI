using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repositories;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<Category> getById(int id)
        {
            if (id == null)
                throw new Exception("Must insert id");
            return await _categoryRepository.getById(id);
        }
    }
}
