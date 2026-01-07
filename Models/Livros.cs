namespace GestaoDeLivros.models
{  public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string Editora { get; set; } = string.Empty;
        public int AnoPublicado { get; set; }
        public int NumeroPaginas { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public string Resumo { get; set; } = string.Empty;
    }

}
    
       
    
