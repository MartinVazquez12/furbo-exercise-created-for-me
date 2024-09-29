using AutoMapper;
using furboWebApi.Dtos;
using furboWebApi.Models;
using System.Text.RegularExpressions;

namespace furboWebApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Jugador, JugadorDto>()
            .ForMember(dest => dest.id_jugador, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.nombredto, opt => opt.MapFrom(src => src.Nombre))
            .ForMember(dest => dest.posdto, opt => opt.MapFrom(src => src.Posicion))
            .ForMember(dest => dest.valordto, opt => opt.MapFrom(src => src.ValorMercado))
            .ForMember(dest => dest.edaddto, opt => opt.MapFrom(src => src.Edad))
            .ForMember(dest => dest.clubnamedto, opt => opt.MapFrom(src => src.IdClubNavigation.Club))
            .ReverseMap();

            CreateMap<Jugador, JugadorPostDto>()
            .ForMember(dest => dest.id_post, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.nombrepost, opt => opt.MapFrom(src => src.Nombre))
            .ForMember(dest => dest.pospost, opt => opt.MapFrom(src => src.Posicion))
            .ForMember(dest => dest.valorpost, opt => opt.MapFrom(src => src.ValorMercado))
            .ForMember(dest => dest.edadpost, opt => opt.MapFrom(src => src.Edad))
            .ForMember(dest => dest.id_clube, opt => opt.MapFrom(src => src.IdClub))
            .ReverseMap();

            CreateMap<Clube, ClubDto>()
            .ForMember(dest => dest.id_club, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.clubdto, opt => opt.MapFrom(src => src.Club))
            .ReverseMap();

        }
    }
}
