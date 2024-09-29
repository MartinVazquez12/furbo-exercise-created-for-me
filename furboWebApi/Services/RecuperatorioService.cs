using AutoMapper;
using furboWebApi.Dtos;
using furboWebApi.Models;
using furboWebApi.Repositories.Interfaces;
using furboWebApi.Services.Interfaz;
using furboWebApi.Validators;
using System.Net;

namespace furboWebApi.Services
{
    public class RecuperatorioService : IRecuperatorioService
    {
        private readonly IJugadorRepo _jugadorRepository;
        private readonly IClubRepo _clubRepository;
        private readonly IMapper _mapper;
        private readonly JugadorPostDtoValidator _validator;

        public RecuperatorioService(
            IJugadorRepo jugadorRepository,
            IClubRepo clubRepository,
            IMapper mapper,
            JugadorPostDtoValidator validator)
        {
            _jugadorRepository = jugadorRepository;
            _clubRepository = clubRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<ApiResponseDto<List<ClubDto>>> GetClubesAsync()
        {
            var response = new ApiResponseDto<List<ClubDto>>();

            var listClubes = await _clubRepository.GetClubs();

            if (listClubes != null && listClubes.Count > 0) 
            {
                var clubesDto = _mapper.Map<List<ClubDto>>(listClubes);
                response.Data = clubesDto;
                response.Success = true;
                response.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                response.SetError("No se encontraron clubes", HttpStatusCode.InternalServerError);
            }
            return response;
        }

        public async Task<ApiResponseDto<JugadorDto>> GetJugadorById(Guid id)
        {
            var response = new ApiResponseDto<JugadorDto>();

            var jugador = await _jugadorRepository.GetJugadorById(id);

            if (jugador != null)
            {
                var jugadorDto = _mapper.Map<JugadorDto>(jugador);
                response.Data = jugadorDto;
                response.Success = true;
                response.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                response.SetError("No se encontro jugador con ese id", HttpStatusCode.InternalServerError);
            }
            return response;
        }

        public async Task<ApiResponseDto<List<JugadorDto>>> GetJugadoresAsync()
        {
            var response = new ApiResponseDto<List<JugadorDto>>();

            var listJug = await _jugadorRepository.GetJugadores();

            if (listJug != null && listJug.Count > 0)
            {
                var jugDto = _mapper.Map<List<JugadorDto>>(listJug);
                response.Data = jugDto;
                response.Success = true;
                response.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                response.SetError("No se encontraron jugadores", HttpStatusCode.InternalServerError);
            }
            return response;
        }

        public async Task<ApiResponseDto<JugadorPostDto>> PostJugador(JugadorPostDto jugadorPostDto)
        {
            var response = new ApiResponseDto<JugadorPostDto>();

            var validacion = await _validator.ValidateAsync(jugadorPostDto);
            if (!validacion.IsValid)
            {
                response.SetError("Error al agregar los campos",HttpStatusCode.BadRequest);
                return response;
            }
            try
            {
                var existeJugador = await _jugadorRepository.JugadorExiste(jugadorPostDto.nombrepost);

                if (existeJugador)
                {
                    response.SetError("Jugador ya existente", HttpStatusCode.BadRequest);
                    return response;
                }

                var jugador = _mapper.Map<Jugador>(jugadorPostDto);
                jugador.Id = Guid.NewGuid();

                await _jugadorRepository.AddJugador(jugador);

                var jugadorAdd = _mapper.Map<JugadorPostDto>(jugador);
                response.Success = true;
                response.Data = jugadorAdd;
                response.StatusCode = HttpStatusCode.OK;
                return response;

            }
            catch (Exception)
            {
                response.SetError("Error al añadir el jugador", HttpStatusCode.InternalServerError);
                throw;
            }
        }
    }
}
