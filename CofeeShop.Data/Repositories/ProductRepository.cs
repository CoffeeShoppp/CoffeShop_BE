using CofeeShop.Data.Entities;
using CofeeShop.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CofeeShop.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products
                .Include(x => x.Cate)
                .Where(x => x.Isdeleted != true)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(x => x.Cate)
                .FirstOrDefaultAsync(x => x.Productid == id && x.Isdeleted != true);
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task UpdateAsync(Product product)
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            product.Isdeleted = true;
            await _context.SaveChangesAsync();
        }
    }
}
