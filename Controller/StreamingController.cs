using API_Filme.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_StreamingFilme.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreamingController : ControllerBase
    {
        private readonly Contexto _context;
        public StreamingController(Contexto context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<StreamingFilme>> Get() => await _context.StreamingFilmes.ToListAsync();


        [HttpGet("id")]
        [ProducesResponseType(typeof(StreamingFilme), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var resultado = await _context.StreamingFilmes.FindAsync(id);

            return resultado == null ? NotFound() : Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StreamingFilme model)
        {
            await _context.StreamingFilmes.AddAsync(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
        }

        [HttpPut("id")]
        [ProducesResponseType(typeof(StreamingFilme), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, StreamingFilme model)
        {
            if (id != model.Id) return BadRequest();

            _context.Entry(model).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var excluirAtividade = await _context.StreamingFilmes.FindAsync(id);

            if (excluirAtividade == null) return NotFound();

            _context.Remove(excluirAtividade);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
