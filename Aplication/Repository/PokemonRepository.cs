﻿using DataBase;
using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Repository
{
    public class PokemonRepository
    {
        private readonly AplicationContext _dbContext;

        public PokemonRepository(AplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Pokemon pokemon)
        {
            await _dbContext.AddAsync(pokemon);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pokemon pokemon)
        {
            _dbContext.Entry(pokemon).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Pokemon pokemon)
        {
            _dbContext.Set<Pokemon>().Remove(pokemon);
            await _dbContext.SaveChangesAsync();
        }
        //GetListAsync
        public async Task<List<Pokemon>> GetAllAsync()
        {
            return await _dbContext.Set<Pokemon>().ToListAsync();
        }
        public async Task<Pokemon> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Pokemon>().FindAsync(id);
        }

    }
}
