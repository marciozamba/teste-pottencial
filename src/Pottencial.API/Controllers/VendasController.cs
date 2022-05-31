using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pottencial.Application.Interfaces;
using Pottencial.Core.Model.Commands.Vendas;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Pottencial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly IVendaService _vendaService;

        public VendasController(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegistrarVenda(InserirVendaCommand command)
        {
            var resultado = await _vendaService.RegistrarVenda(command);

            if (!resultado.Sucesso)
            {
                return BadRequest(resultado.Erros);
            }

            return CreatedAtAction("BuscarVenda", new { id = resultado.Id }, resultado.Id);
        }

        [HttpGet("{id:int}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscarVenda(int id)
        {
            var resultado = await _vendaService.BuscarVenda(id);

            if(resultado == null)
            {
                return NotFound();
            }

            return Ok(resultado);
        }

        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ListarVendas()
        {
            var resultado = await _vendaService.ListarVendas();

            return Ok(resultado);
        }

        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AtualizarVenda(AtualizarVendaCommand command)
        {
            var resultado = await _vendaService.AtualizarVenda(command);

            if (!resultado.Sucesso)
            {
                return BadRequest(resultado.Erros);
            }

            return NoContent();
        }
    }
}