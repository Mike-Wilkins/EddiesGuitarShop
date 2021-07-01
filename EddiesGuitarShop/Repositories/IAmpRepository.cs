using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IAmpRepository
    {
        Task<Amp> Add(Amp amp);
        Task<Amp> Delete(int id);
        Amp Update(Amp amp);
        Task<Amp> GetProduct(int id);
        Task<IEnumerable<Amp>> GetAllProducts();
    }
}
