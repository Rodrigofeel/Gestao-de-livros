using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestaoDeLivros.models;
using GestaoDeLivros.Data;

namespace GestaoDeLivros.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LivrosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Livro>>> GetAll()
        {
            var livros = await _context.Livros.ToListAsync();
            return Ok(livros);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> GetById(int id)
        {
            var livro = await _context.Livros.FindAsync(id);

            if (livro == null)
            {
                return NotFound($"Livro com ID {id} não encontrado");
            }

            return Ok(livro);
        }

        [HttpPost]
        public async Task<ActionResult<Livro>> Create([FromBody] Livro novoLivro)
        {
            // Validação dos dados de entrada
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _context.Livros.AnyAsync(l => l.ISBN == novoLivro.ISBN))
            {
                return Conflict("Já existe um livro com este ISBN");
            }

            try
            {
                _context.Livros.Add(novoLivro);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = novoLivro.Id }, novoLivro);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Erro ao salvar o livro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Livro livroAtualizado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != livroAtualizado.Id)
            {
                return BadRequest("ID não correspondente");
            }

            var livro = await _context.Livros.FindAsync(id);
            if (livro == null)
            {
                return NotFound($"Livro com ID {id} não encontrado");
            }

            if (await _context.Livros.AnyAsync(l => l.ISBN == livroAtualizado.ISBN && l.Id != id))
            {
                return Conflict("Já existe outro livro com este ISBN");
            }

            livro.Titulo = livroAtualizado.Titulo;
            livro.Categoria = livroAtualizado.Categoria;
            livro.Autor = livroAtualizado.Autor;
            livro.Editora = livroAtualizado.Editora;
            livro.AnoPublicado = livroAtualizado.AnoPublicado;
            livro.NumeroPaginas = livroAtualizado.NumeroPaginas;
            livro.ISBN = livroAtualizado.ISBN;
            livro.Resumo = livroAtualizado.Resumo;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(livro);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Erro ao atualizar o livro");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro == null)
            {
                return NotFound($"Livro com ID {id} não encontrado");
            }

            try
            {
                _context.Livros.Remove(livro);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Erro ao deletar o livro");
            }
        }
    }
}