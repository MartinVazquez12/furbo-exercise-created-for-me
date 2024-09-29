using furboWebApi.Models;

namespace furboWebApi.Repositories.Interfaces
{
    public interface IJugadorRepo
    {
        Task<List<Jugador>> GetJugadores();
        Task<Jugador> AddJugador(Jugador jugador);
        Task<Jugador> GetJugadorById(Guid id);
        Task<bool> JugadorExiste(string nombre);
    }
}
