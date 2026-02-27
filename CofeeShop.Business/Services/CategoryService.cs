using CofeeShop.Business.IServices;
using CofeeShop.Business.Models;
using CofeeShop.Data.Entities;
using CofeeShop.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CofeeShop.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var data = await _repository.GetAllAsync();

            return data.Select(x => new CategoryDto
            {
                Cateid = x.Cateid,
                Catename = x.Catename
            }).ToList();
        }

        public async Task<CategoryDto?> GetByIdAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null) return null;

            return new CategoryDto
            {
                Cateid = category.Cateid,
                Catename = category.Catename
            };
        }

        public async Task<CategoryDto> CreateAsync(CreateCategoryRequest request)
        {
            var category = new Category
            {
                Catename = request.Catename,
                Createdby = request.Createdby,
                Createdat = DateTime.Now,
                Isdeleted = false
            };

            var result = await _repository.CreateAsync(category);

            return new CategoryDto
            {
                Cateid = result.Cateid,
                Catename = result.Catename
            };
        }

        public async Task<CategoryDto?> UpdateAsync(int id, UpdateCategoryRequest request)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null) return null;

            category.Catename = request.Catename;
            category.Modifiedby = request.Modifiedby;
            category.Modifiedat = DateTime.Now;

            await _repository.UpdateAsync(category);

            return new CategoryDto
            {
                Cateid = category.Cateid,
                Catename = category.Catename
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null) return false;

            await _repository.DeleteAsync(category);
            return true;
        }
    }
}
