using Aplication.Services;
using Aplication.ViewModel;
using DataBase;
using Microsoft.AspNetCore.Mvc;

namespace Pokedex.Controllers
{
    public class TypeOfPokemonsController : Controller
    {
        private readonly TypeOfPokemonService _typeOfPokemonsService;

        public TypeOfPokemonsController(AplicationContext dbContext)
        {
            _typeOfPokemonsService = new (dbContext);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _typeOfPokemonsService.GetAllViewModel());
        }

        public IActionResult EditOCreate()
        {
            return View("EditCreate", new TypeEditCreateViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> EditOCreate(TypeEditCreateViewModel vm)
        {
            await _typeOfPokemonsService.Add(vm);
            return RedirectToRoute(new { controller = "TypeOfPokemons", action = "Index" });
        }

    }
}
