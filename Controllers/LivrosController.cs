using Microsoft.AspNetCore.Mvc;
using GestaoDeLivros.models;

namespace GestaoDeLivros.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
        private static List<Livro> livros = new List<Livro>
        {

        };

        [HttpGet]
        public ActionResult<List<Livro>> GetALL()
        {
            return Ok(livros);
        }
        
        [HttpGet("{id}")]
        public ActionResult<Livro> GetById(int id)
        {
            var livro = livros.FirstOrDefault(l => l.Id == id);

            if (livro == null)
            {
                return NotFound($"Livro com ID {id} não encontrado");
            }

            return Ok(livro);
        }

        [HttpPost]
        public ActionResult<Livro> Create([FromBody] Livro novoLivro)
        {
            novoLivro.Id = livros.Any() ? livros.Max(l => l.Id) + 1 : 1;

            livros.Add(novoLivro);

            return CreatedAtAction(nameof(GetById), new { id = novoLivro.Id }, novoLivro);

        }

        [HttpPut("{id}")]
        public ActionResult Uptade(int id, [FromBody] Livro livroAtualizado)
        {
            var livro = livros.FirstOrDefault(l => l.Id == id);

            if (livro == null)
            {
                return NotFound($"Livro com ID {id} não encontrado");
            }

            livro.Titulo = livroAtualizado.Titulo;
            livro.Categoria = livroAtualizado.Categoria;
            livro.Autor = livroAtualizado.Autor;
            livro.Editora = livroAtualizado.Editora;
            livro.AnoPublicado = livroAtualizado.AnoPublicado;
            livro.NumeroPaginas = livroAtualizado.NumeroPaginas;
            livro.ISBN = livroAtualizado.ISBN;
            livro.Resumo = livroAtualizado.Resumo;

            return Ok(livro);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var livro = livros.FirstOrDefault(l => l.Id == id);

            if (livro == null)
            {
                return NotFound($"Livro com ID {id} não encontrado");
            }

            livros.Remove(livro);
            return NoContent();
        }
    }
}