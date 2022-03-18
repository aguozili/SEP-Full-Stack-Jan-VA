using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastsController : ControllerBase
    {
        private ICastService _castService;

        public CastsController(ICastService castService)
        {
            _castService = castService;
        }


        [Route("{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetMovie(int id)
        {
            var cast = await _castService.GetCastDetails(id);

            //convert movie data to JSON format
            if (cast == null)
            {
                return NotFound(new { error = $"Cast Not Found for id: {id}" });
            }
            return Ok(cast);

        }
    }
}
