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
    public class CiudadesController : ControllerBase
    {
        private readonly ICiudadService _ciudadService;

        public CiudadesController(ICiudadService ciudadService)
        {
            _ciudadService = ciudadService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CiudadDTO>>> Gets()
        {
            var ciudades = _ciudadService.GetAll();
            if (ciudades == null)
            {
                return NotFound();
            }
            return Ok(ciudades);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CiudadDTO ciudad)
        {
            try
            {
                _ciudadService.Edit(id, ciudad);
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
        public async Task<ActionResult<Ciudad>> Create(CiudadDTO ciudad)
        {
            var ciudades = _ciudadService.GetAll();
            if (ciudades == null)
            {
                return Problem("Entity set 'ViajerosDbContext.Ciudad'  is null.");
            }
            try
            {
                _ciudadService.Add(ciudad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(ciudad);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ciudades = _ciudadService.GetAll();
            if (ciudades == null)
            {
                return NotFound();
            }

            try
            {
                var deleteFlag = _ciudadService.Delete(id);
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
