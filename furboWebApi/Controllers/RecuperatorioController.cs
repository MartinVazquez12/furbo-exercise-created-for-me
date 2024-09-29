using furboWebApi.Dtos;
using furboWebApi.Models;
using furboWebApi.Services;
using furboWebApi.Services.Interfaz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace furboWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecuperatorioController : ControllerBase
    {
        private readonly IRecuperatorioService _service;
        public RecuperatorioController(IRecuperatorioService service)
        {
            _service = service;
        }

        [HttpGet("/GetClubes")]
        public async Task<ActionResult> GetClubes()
        {
            return Ok(await _service.GetClubesAsync());
        }

        [HttpGet("/GetJugadores")]
        public async Task<ActionResult> GetJugadores()
        {
            return Ok(await _service.GetJugadoresAsync());
        }

        [HttpGet("/GetJugadorById/{id}")]
        public async Task<ActionResult> GetJugadorById(Guid id)
        {
            var result = await _service.GetJugadorById(id);
            if (!result.Success)
            {
                return StatusCode((int)result.StatusCode, result.Data);
            }
            return Ok(result.Data);
        }

        [HttpPost("/PostJugador")]
        public async Task<IActionResult> PostJugador([FromBody] JugadorPostDto jugador)
        {
            try
            {
                var response = await _service.PostJugador(jugador);

                if (response.Success)
                {
                    return Ok(response.Data);
                }
                else
                {
                    return BadRequest(response.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
