using API_Filme.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_NacionalidadeFilme.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NacionalidadeController : ControllerBase
    {
        private readonly Contexto _context;
        public NacionalidadeController(Contexto context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<NacionalidadeFilme>> Get() => await _context.NacionalidadeFilmes.ToListAsync();


        [HttpGet("id")]
        [ProducesResponseType(typeof(NacionalidadeFilme), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var resultado = await _context.NacionalidadeFilmes.FindAsync(id);

            return resultado == null ? NotFound() : Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Create(NacionalidadeFilme model)
        {
            await _context.NacionalidadeFilmes.AddAsync(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
        }

        [HttpPut("id")]
        [ProducesResponseType(typeof(NacionalidadeFilme), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, NacionalidadeFilme model)
        {
            if (id != model.Id) return BadRequest();

            _context.Entry(model).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var excluirAtividade = await _context.NacionalidadeFilmes.FindAsync(id);

            if (excluirAtividade == null) return NotFound();

            _context.Remove(excluirAtividade);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
