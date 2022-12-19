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
    public class PokemonService
    {
        private readonly PokemonRepository _pokemonRepository;

        public PokemonService(AplicationContext dbContext)
        {
            _pokemonRepository = new(dbContext);
        }

        public async Task Add(PokemonEditCreateViewModel vm)
        {
            Pokemon Pokemon = new();
            Pokemon.Name = vm.Name;
            Pokemon.TypeOfPokemonId = vm.TypeOfPokemonId;
            Pokemon.URLImage = vm.URLImage;
            Pokemon.SecondTypeOfPokemonId = vm.SecondTypeOfPokemonId;
            Pokemon.RegionId = vm.RegionId;
            await _pokemonRepository.AddAsync(Pokemon);
        }

        public async Task Update(PokemonEditCreateViewModel vm)
        {
            Pokemon Pokemon = new();
            Pokemon.Id = vm.Id;
            Pokemon.Name = vm.Name;
            Pokemon.TypeOfPokemonId = vm.TypeOfPokemonId;
            Pokemon.URLImage = vm.URLImage;
            Pokemon.SecondTypeOfPokemonId = vm.SecondTypeOfPokemonId;
            Pokemon.RegionId = vm.RegionId;
            await _pokemonRepository.UpdateAsync(Pokemon);
        }

        public async Task<PokemonEditCreateViewModel> GetByIdSaveViewModel(int id)
        {
            var pokemon = await _pokemonRepository.GetByIdAsync(id);

            PokemonEditCreateViewModel vm = new();
            vm.Id = pokemon.Id;
            vm.Name = pokemon.Name;
            vm.TypeOfPokemonId = pokemon.TypeOfPokemonId;
            vm.SecondTypeOfPokemonId = pokemon.SecondTypeOfPokemonId;
            vm.URLImage = pokemon.URLImage;
            vm.RegionId = pokemon.RegionId;

            return vm;
        }

        public async Task<List<PokemonViewModel>> GetAllViewModel()
        {
            var pokemonList = await _pokemonRepository.GetAllAsync();
            return pokemonList.Select(pokemon => new PokemonViewModel
            {
                Name = pokemon.Name,
                Id = pokemon.Id,
                URLImage = pokemon.URLImage,
                TypeOfPokemonId = pokemon.TypeOfPokemonId,
                SecondTypeOfPokemonId= pokemon.SecondTypeOfPokemonId
            }).ToList();
        }

        public async Task Delete(int id)
        {
            var pokemon = await _pokemonRepository.GetByIdAsync(id);
            await _pokemonRepository.DeleteAsync(pokemon);
        }
    }
}