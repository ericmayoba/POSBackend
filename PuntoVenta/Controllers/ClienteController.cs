using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace PuntoVenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _clienteService.GetAll());
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _clienteService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> PostAsync(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok (await _clienteService.Create(cliente));
        }

        [HttpPut]
        public async Task<IActionResult> Put(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _clienteService.Update(cliente));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _clienteService.Delete(id));
        }
    }
}