using DataBase;
using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Repository
{
    public class TypeRepository
    {
        private readonly AplicationContext _dbContext;

        public TypeRepository(AplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(TypeOfPokemon TypeOfPokemon)
        {
            await _dbContext.AddAsync(TypeOfPokemon);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TypeOfPokemon TypeOfPokemon)
        {
            _dbContext.Entry(TypeOfPokemon).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TypeOfPokemon TypeOfPokemon)
        {
            _dbContext.Set<TypeOfPokemon>().Remove(TypeOfPokemon);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<TypeOfPokemon>> GetListAsync()
        {
            return await _dbContext.Set<TypeOfPokemon>().ToListAsync();
        }
        public async Task<TypeOfPokemon> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TypeOfPokemon>().FindAsync(id);
        }


    }
}
