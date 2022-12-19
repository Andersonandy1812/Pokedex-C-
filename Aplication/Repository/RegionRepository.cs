using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace Aplication.Repository
{
    public class RegionRepository
    {
        private readonly AplicationContext _dbContext;

        public RegionRepository(AplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Region region)
        {
            await _dbContext.AddAsync(region);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Region region)
        {
            _dbContext.Entry(region).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Region region)
        {
            _dbContext.Set<Region>().Remove(region);
            await _dbContext.SaveChangesAsync();
        }
        
        public async Task<List<Region>> GetListAsync()
        {
            return await _dbContext.Set<Region>().ToListAsync();
        }
        public async Task<Region> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Region>().FindAsync(id);
        }

    }
}
