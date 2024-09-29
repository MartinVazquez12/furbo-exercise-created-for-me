using furboWebApi.Models;
using furboWebApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace furboWebApi.Repositories
{
    public class JugadorRepo : IJugadorRepo
    {
        private readonly FurboDbContext _context;

        public JugadorRepo(FurboDbContext context)
        {
            _context = context;
        }
        public async Task<Jugador> AddJugador(Jugador jugador)
        {
            _context.Add(jugador);
            await _context.SaveChangesAsync();
            return jugador;
        }

        public async Task<Jugador> GetJugadorById(Guid id)
        {
            var jugador = await _context.Jugadors
                .Include(x => x.IdClubNavigation)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (jugador == null)
            {
                throw new Exception();
            }
            return jugador;
        }

        public async Task<List<Jugador>> GetJugadores()
        {
            return await _context.Jugadors
                .Include(x => x.IdClubNavigation)
                .ToListAsync();
        }

        public async Task<bool> JugadorExiste(string nombre)
        {
            var jugadorExiste = await _context.Jugadors.AnyAsync(x=> x.Nombre.Equals(nombre));

            return jugadorExiste;
        }
    }
}
