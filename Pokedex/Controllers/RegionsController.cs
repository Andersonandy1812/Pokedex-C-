using Aplication.Services;
using Aplication.ViewModel;
using DataBase;
using Microsoft.AspNetCore.Mvc;

namespace Pokedex.Controllers
{
    public class RegionsController : Controller
    {
        private readonly RegionService _regionService;

        public RegionsController(AplicationContext dbContext)
        {
            _regionService = new(dbContext);
        }
        public async Task<IActionResult> Index()
        {
            return View(await _regionService.GetAllViewModel());
        }

        public IActionResult EditOCreate()
        {
            return View("EditCreate", new EditCreateViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> EditOCreate(EditCreateViewModel vm)
        {
           await _regionService.Add(vm);
            return RedirectToRoute(new {controller = "Regions", action = "Index"});
        }
        //-----------------------------------------Edit-------------------------------------
        public async Task<IActionResult> Edit(int id)
        {
            return View("EditCreate", await _regionService.GetByIdSaveViewModel(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(RegionEditCreateViewModel vm)
        {

            await _regionService.Update(vm);
            return RedirectToRoute(new { controller = "Regions", action = "Index" });
        }

            //----------------------delete------------------------------------------------
            public async Task<IActionResult> Delete(int id)
        {
            return View(await _regionService.GetByIdSaveViewModel(id));
        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _regionService.Delete(id);
            return RedirectToRoute(new { controller = "Regions", action = "Index" });
        }
    }
}
