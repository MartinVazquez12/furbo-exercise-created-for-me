using furboWebApi.Dtos;
using furboWebApi.Models;

namespace furboWebApi.Services.Interfaz
{
    public interface IRecuperatorioService
    {
        Task<ApiResponseDto<List<ClubDto>>> GetClubesAsync();
        Task<ApiResponseDto<List<JugadorDto>>> GetJugadoresAsync();
        Task<ApiResponseDto<JugadorDto>> GetJugadorById(Guid id);
        Task<ApiResponseDto<JugadorPostDto>> PostJugador(JugadorPostDto jugadorPostDto);

    }
}
