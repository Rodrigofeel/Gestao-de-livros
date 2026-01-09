using System.ComponentModel.DataAnnotations;

namespace GestaoDeLivros.models
{  public class Livro
    { 
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O título é obrigatório")]
        public string Titulo { get; set; } = string.Empty;
        [Required(ErrorMessage = "A categoria é obrigatória")]
        public string Categoria { get; set; } = string.Empty;
        [Required(ErrorMessage = "O autor é obrigatório")]
        public string Autor { get; set; } = string.Empty;
        [Required(ErrorMessage = "A editora é obrigatória")]
        public string Editora { get; set; } = string.Empty;
        [Range(1450, 2100, ErrorMessage = "O ano de publicação deve estar entre 1450 e 2100")]
        public int AnoPublicado { get; set; }
        [Range(1, 10000, ErrorMessage = "O número de páginas deve estar entre 1 e 10000")]
        public int NumeroPaginas { get; set; }
        [StringLength(17, MinimumLength = 10, ErrorMessage = "O ISBN deve ter entre 10 e 17 caracteres")]
        public string ISBN { get; set; } = string.Empty;
        [StringLength(1000, ErrorMessage = "O resumo não pode exceder 1000 caracteres")]
        public string Resumo { get; set; } = string.Empty;
    }

}
