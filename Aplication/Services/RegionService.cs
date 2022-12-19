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
    public class RegionService
    {
        private readonly RegionRepository _regionRepository;

        public RegionService(AplicationContext dbContext)
        {
            _regionRepository = new(dbContext);
        }

        public async Task Add(EditCreateViewModel vm)
        {
            Region region = new();
            region.Name = vm.Name; 
            await _regionRepository.AddAsync(region);
        }

        public async Task<List<RegionViewModel>> GetAllViewModel()
        {
            var regionList = await _regionRepository.GetListAsync();
            return regionList.Select(region => new RegionViewModel
            {
                Name = region.Name,
                Id = region.Id
            }).ToList();
        }

        public async Task<RegionEditCreateViewModel> GetByIdSaveViewModel(int id)
        {
            var pokemon = await _regionRepository.GetByIdAsync(id);

            RegionEditCreateViewModel vm = new();
            vm.Id = pokemon.Id;
            vm.Name = pokemon.Name;
            return vm;
        }

        public async Task Update(RegionEditCreateViewModel vm)
        {
            Region Region = new();
            Region.Id = vm.Id;
            Region.Name = vm.Name;
            await _regionRepository.UpdateAsync(Region);
        }

        public async Task Delete(int id)
        {
            var pokemon = await _regionRepository.GetByIdAsync(id);
            await _regionRepository.DeleteAsync(pokemon);
        }

    }
}
