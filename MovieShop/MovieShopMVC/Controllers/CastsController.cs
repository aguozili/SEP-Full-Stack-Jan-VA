using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class CastsController: Controller
    {
        private ICastService _castService;
        public CastsController(ICastService castService)
        {
            _castService = castService;
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            //cast service with details
            //pass the cast detail data to view

            var castDetails = await _castService.GetCastDetails(id);
            return View(castDetails);
        }
    }
}
