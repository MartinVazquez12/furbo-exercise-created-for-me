using furboWebApi.Models;

namespace furboWebApi.Dtos
{
    public class JugadorPostDto
    {
        public Guid id_post { get; set; }

        public string nombrepost { get; set; } = null!;

        public string pospost { get; set; } = null!;

        public string valorpost { get; set; } = null!;

        public string edadpost { get; set; } = null!;

        public Guid id_clube { get; set; }
    }
}
