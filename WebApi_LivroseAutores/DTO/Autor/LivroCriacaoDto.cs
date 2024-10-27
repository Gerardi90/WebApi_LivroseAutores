using WebApi_LivroseAutores.DTO.Vinculo;

namespace WebApi_LivroseAutores.DTO.Livro
{
    public class LivroCriacaoDto
    {
        public string Titulo { get; set; }
        public AutorVinculoDto Autor { get; set; }
    }
}
