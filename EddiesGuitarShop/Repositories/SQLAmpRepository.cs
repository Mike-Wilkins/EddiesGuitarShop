using DataLayer.Models;
using DataLayer.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class SQLAmpRepository : IAmpRepository
    {
        public IApplicationDbContext _context;

        public SQLAmpRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Amp> Add(Amp amp)
        {
            _context.Amps.Add(amp);
            await _context.SaveChangesAsync();
            return amp;
        }

        public async Task<Amp> Delete(int id)
        {
            var amp = await _context.Amps.Where(p => p.ProductId == id).FirstOrDefaultAsync();
            _context.Amps.Remove(amp);
            await _context.SaveChangesAsync();
            return amp;
        }

        public async Task<IEnumerable<Amp>> GetAllProducts()
        {
            var amps = await _context.Amps.OrderBy(p => p.ProductId).ToListAsync();
            return amps;
        }

        public async Task<Amp> GetProduct(int id)
        {
            var amp = await _context.Amps.Where(p => p.ProductId == id).FirstOrDefaultAsync();
            return amp;
        }

        public Amp Update(Amp amp)
        {
            var productUpdate = _context.Amps.Attach(amp);
            productUpdate.State = EntityState.Modified;
            _context.SaveChanges();
            return amp;
        }
    }
}
