using furboWebApi.Models;

namespace furboWebApi.Repositories.Interfaces
{
    public interface IClubRepo
    {
        Task<List<Clube>> GetClubs();
    }
}
