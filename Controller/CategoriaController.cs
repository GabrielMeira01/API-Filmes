using API_Filme.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_CategoriaFilme.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly Contexto _context;
        public CategoriaController(Contexto context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoriaFilme>> Get() => await _context.CategoriaFilmes.ToListAsync();


        [HttpGet("id")]
        [ProducesResponseType(typeof(CategoriaFilme), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var resultado = await _context.CategoriaFilmes.FindAsync(id);

            return resultado == null ? NotFound() : Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoriaFilme model)
        {
            await _context.CategoriaFilmes.AddAsync(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
        }

        [HttpPut("id")]
        [ProducesResponseType(typeof(CategoriaFilme), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, CategoriaFilme model)
        {
            if (id != model.Id) return BadRequest();

            _context.Entry(model).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var excluirAtividade = await _context.CategoriaFilmes.FindAsync(id);

            if (excluirAtividade == null) return NotFound();

            _context.Remove(excluirAtividade);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
