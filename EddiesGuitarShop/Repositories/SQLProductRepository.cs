using DataLayer.Models;
using DataLayer.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class SQLProductRepository : IProductRepository
    {
        public IApplicationDbContext _context;
        public SQLProductRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Product> Add(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Delete(int id)
        {
            var product = await _context.Products.Where(p => p.ProductId == id).FirstOrDefaultAsync();
            _context.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products = await _context.Products.OrderBy(p => p.ProductId).ToListAsync();
            return products;
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = await _context.Products.Where(p => p.ProductId == id).FirstOrDefaultAsync();
            return product;
        }

        public Product Update(Product product)
        {
            var productUpdate = _context.Products.Attach(product);
            productUpdate.State = EntityState.Modified;
            _context.SaveChanges();
            return product;
        }
    }
}
