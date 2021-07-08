
using DataLayer.Models;
using DataLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace DataLayer.Repositories
{
    public interface IProductRepository
    {
        Task<Product> Add(Product product);
        Task<Product> Delete(int id);
        Product Update(Product product);
        Task<Product> GetProduct(int id);
        Task<IEnumerable<Product>> GetAllProducts(ProductIndexViewModel filterProduct);

    }
}
