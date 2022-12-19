using Aplication.Repository;
using Aplication.ViewModel;
using DataBase;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services
{
    public class TypeOfPokemonService
    {
        private readonly TypeRepository _typeRepository;

        public TypeOfPokemonService(AplicationContext dbContext)
        {
            _typeRepository = new(dbContext);
        }

        public async Task Add(TypeEditCreateViewModel vm)
        {
            TypeOfPokemon typeOfPokemon = new();
            typeOfPokemon.Name = vm.Name;
            await _typeRepository.AddAsync(typeOfPokemon);
        }

        public async Task<List<TypeOfPokemonViewModel>> GetAllViewModel()
        {
            var TypeOfPokemonList = await _typeRepository.GetListAsync();
            return TypeOfPokemonList.Select(TypeOfPokemon => new TypeOfPokemonViewModel
            {
                Name = TypeOfPokemon.Name,
                Id = TypeOfPokemon.Id
            }).ToList();
        }
    }
}
