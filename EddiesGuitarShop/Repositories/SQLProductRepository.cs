
using DataLayer.Models;
using DataLayer.Services;
using DataLayer.ViewModels;
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

        public async Task<IEnumerable<Product>> GetAllProducts(ProductIndexViewModel filterProduct)
        {
            var filter = filterProduct.FilterType.ToString();

            var products = from p in _context.Products select p;

            switch (filter)
            {
                case "PriceHighToLow":
                    products = products.OrderByDescending(s => s.Price);
                    break;
                case "PriceLowToHigh":
                    products = products.OrderBy(s => s.Price);
                    break;
                default:
                    products = products.OrderBy(s => s.ProductId);
                    break;
            }
            return await products.ToListAsync();

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
