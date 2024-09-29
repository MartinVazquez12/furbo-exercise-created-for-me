using furboWebApi.Models;

namespace furboWebApi.Dtos
{
    public class JugadorDto
    {
        public Guid id_jugador { get; set; }

        public string nombredto { get; set; } = null!;

        public string posdto { get; set; } = null!;

        public string valordto { get; set; } = null!;

        public string edaddto { get; set; } = null!;

        public string clubnamedto { get; set; } = null!;
    }
}
