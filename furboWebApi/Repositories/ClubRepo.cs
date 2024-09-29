using furboWebApi.Models;
using furboWebApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace furboWebApi.Repositories
{
    public class ClubRepo : IClubRepo
    {
        private readonly FurboDbContext _context;

        public ClubRepo(FurboDbContext context)
        {
            _context = context;
        }

        public async Task<List<Clube>> GetClubs()
        {
            return await _context.Clubes.ToListAsync();
        }
    }
}
