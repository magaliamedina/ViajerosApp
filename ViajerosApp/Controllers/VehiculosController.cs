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
    public class VehiculosController : ControllerBase
    {
        private readonly IVehiculoService _vehiculoService;

        public VehiculosController(IVehiculoService vehiculoService)
        {
            _vehiculoService = vehiculoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehiculoDTO>>> Gets()
        {
            var vehiculos = _vehiculoService.GetAll();
            if (vehiculos == null)
            {
                return NotFound();
            }
            return Ok(vehiculos);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, VehiculoDTO vehiculo)
        {
            try
            {
                _vehiculoService.Edit(id, vehiculo);
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
        public async Task<ActionResult<Vehiculo>> Create(VehiculoDTO vehiculo)
        {
            var vehiculos = _vehiculoService.GetAll();
            if (vehiculos == null)
            {
                return Problem("Entity set 'ViajerosDbContext.Vehiculos'  is null.");
            }
            try
            {
                _vehiculoService.Add(vehiculo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(vehiculo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vehiculos = _vehiculoService.GetAll();
            if (vehiculos == null)
            {
                return NotFound();
            }

            try
            {
                var deleteFlag = _vehiculoService.Delete(id);
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
    }
}
