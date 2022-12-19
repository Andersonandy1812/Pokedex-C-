using Aplication.Services;
using Aplication.ViewModel;
using DataBase;
using Microsoft.AspNetCore.Mvc;

namespace Pokedex.Controllers
{
    public class PokemonsController : Controller
    {
        private readonly PokemonService _pokemonService;
        public PokemonsController(AplicationContext dbContext)
        {
            _pokemonService = new(dbContext);
        }
        public async Task<IActionResult> Index()
        {
            return View(await _pokemonService.GetAllViewModel());
        }

        public IActionResult EditOCreate()
        {
            return View("EditCreate", new PokemonEditCreateViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> EditOCreate(PokemonEditCreateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("EditCreate");
            }
            await _pokemonService.Add(vm);
            return RedirectToRoute(new { controller = "Pokemons", action = "Index" });
        }
        //-----------------------------------------Edit-------------------------------------
        public async Task<IActionResult> Edit(int id)
        {
            if (!ModelState.IsValid)
            {
                return View("EditCreate");
            }
            return View("EditCreate", await _pokemonService.GetByIdSaveViewModel(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PokemonEditCreateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("EditCreate", vm);
            }
            await _pokemonService.Update(vm);
            return RedirectToRoute(new { controller = "Pokemons", action = "Index" });
        }
        //----------------------delete------------------------------------------------
        public async Task<IActionResult> Delete(int id)
        { 
            return View(await _pokemonService.GetByIdSaveViewModel(id));
        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _pokemonService.Delete(id);
            return RedirectToRoute(new { controller = "Pokemons", action = "Index" });
        }
    }
}
