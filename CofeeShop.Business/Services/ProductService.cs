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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();

            return products.Select(x => new ProductDto
            {
                Productid = x.Productid,
                Productname = x.Productname,
                Price = x.Price,
                Cateid = x.Cateid,
                CategoryName = x.Cate?.Catename
            }).ToList();
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) return null;

            return new ProductDto
            {
                Productid = product.Productid,
                Productname = product.Productname,
                Price = product.Price,
                Cateid = product.Cateid,
                CategoryName = product.Cate?.Catename
            };
        }

        public async Task<ProductDto> CreateAsync(CreateProductRequest request)
        {
            var product = new Product
            {
                Productname = request.Productname,
                Price = request.Price,
                Cateid = request.Cateid,
                Createdby = request.Createdby,
                Createdat = DateTime.Now,
                Isdeleted = false
            };

            var result = await _repository.CreateAsync(product);

            return new ProductDto
            {
                Productid = result.Productid,
                Productname = result.Productname,
                Price = result.Price,
                Cateid = result.Cateid
            };
        }

        public async Task<ProductDto?> UpdateAsync(int id, UpdateProductRequest request)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) return null;

            product.Productname = request.Productname;
            product.Price = request.Price;
            product.Cateid = request.Cateid;
            product.Modifiedby = request.Modifiedby;
            product.Modified = DateTime.Now;

            await _repository.UpdateAsync(product);

            return new ProductDto
            {
                Productid = product.Productid,
                Productname = product.Productname,
                Price = product.Price,
                Cateid = product.Cateid
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) return false;

            await _repository.DeleteAsync(product);
            return true;
        }
    }
}
