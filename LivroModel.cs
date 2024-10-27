namespace WebApi_LivroseAutores
{
    public class LivroModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Sobrenome { get; set; }
        public AutorModel Autor { get; set; }

    }
}
