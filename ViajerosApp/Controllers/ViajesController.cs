using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ViajerosApp.DTO;
using ViajerosApp.Models;
using ViajerosApp.Services;

namespace ViajerosApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajesController : ControllerBase
    {
        private readonly IViajeService _viajeService;

        public ViajesController(IViajeService viajeService)
        {
            _viajeService = viajeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViajeDTO>>> Gets()
        {
            var viajes = _viajeService.GetAll();
            if (viajes == null)
            {
                return NotFound();
            }
            return Ok(viajes);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ViajeDTO viaje)
        {
            try
            {
                _viajeService.Edit(id, viaje);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Viaje>> Create(ViajeDTO viaje)
        {
            var viajes = _viajeService.GetAll();
            if (viajes == null)
            {
                return Problem("Entity set 'ViajerosDbContext.Viajes'  is null.");
            }
            try
            {
                _viajeService.Add(viaje);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(viaje);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var viajes = _viajeService.GetAll();
            if (viajes == null)
            {
                return NotFound();
            }

            try
            {
                var deleteFlag = _viajeService.Delete(id);
                if (!deleteFlag)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return NoContent();
        }

        [HttpGet("destino/{ciudadID:int}")]
        public async Task<ActionResult<IEnumerable<Viaje>>> GetByCiudadDestinoID(int ciudadID)
        {
            var viajes = _viajeService.GetByCiudadDestinoID(ciudadID);
            if (viajes == null)
            {
                return NotFound();
            }
            return viajes;
        }

        [HttpGet("vehiculo/{vehiculoID:int}")]
        public async Task<ActionResult<IEnumerable<Viaje>>> GetByVehiculoID(int vehiculoID)
        {
            var viajes = _viajeService.GetByCiudadDestinoID(vehiculoID);
            if (viajes == null)
            {
                return NotFound();
            }
            return viajes;
        }

        [HttpGet("{fecha:DateTime}")]
        public async Task<ActionResult<IEnumerable<Viaje>>> GetByDate(DateTime fecha)
        {
            var viajes = _viajeService.GetByFecha(fecha);
            if (viajes == null)
            {
                return NotFound();
            }
            return viajes;
        }
    }
}
