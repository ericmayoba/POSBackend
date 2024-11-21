using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace PuntoVenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleVentaController : ControllerBase
    {
        private readonly DetalleVentaService _detalleVentaService;

        public DetalleVentaController(DetalleVentaService detalleVentaService)
        {
            _detalleVentaService = detalleVentaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _detalleVentaService.GetAll());
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _detalleVentaService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(DetalleVenta detalle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _detalleVentaService.Create(detalle));

        }

        [HttpPut]
        public async Task<IActionResult> Put(DetalleVenta  detalleVenta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _detalleVentaService.Update(detalleVenta));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _detalleVentaService.Delete(id));
        }
    }
}