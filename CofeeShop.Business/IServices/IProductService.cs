using CofeeShop.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CofeeShop.Business.IServices
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllAsync();
        Task<ProductDto?> GetByIdAsync(int id);
        Task<ProductDto> CreateAsync(CreateProductRequest request);
        Task<ProductDto?> UpdateAsync(int id, UpdateProductRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
