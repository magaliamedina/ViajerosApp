using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViajerosApp.DTO;
using ViajerosApp.Models;
using ViajerosApp.Services;

namespace ViajerosApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajeroController : ControllerBase
    {
        private readonly IViajeroService _viajeroService;

        public ViajeroController(IViajeroService viajeroService)
        {
            _viajeroService = viajeroService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViajeroDTO>>> Gets()
        {
            var viajeros = _viajeroService.GetAll();
            if (viajeros == null)
            {
                return NotFound();
            }
            return Ok(viajeros);
        }

        [HttpPost]
        public async Task<ActionResult<Viajero>> Create(ViajeroDTO viajero)
        {
            var viajeros = _viajeroService.GetAll();
            if (viajeros == null)
            {
                return Problem("Entity set 'ViajerosDbContext.Viajeros'  is null.");
            }
            try
            {
                _viajeroService.Add(viajero);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(viajero);
        }
    }
}
