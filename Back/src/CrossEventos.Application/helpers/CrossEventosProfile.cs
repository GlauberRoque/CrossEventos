using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CrossEventos.Application.Dtos;
using CrossEventos.Domain;

namespace CrossEventos.Application.helpers
{
    public class CrossEventosProfile : Profile
    {
        public CrossEventosProfile()
        {
            CreateMap<Evento, EventoDto>().ReverseMap();
            CreateMap<Lote, LoteDto>().ReverseMap();
            CreateMap<RedeSocial, RedeSocialDto>().ReverseMap();
            CreateMap<Promotor, PromotorDto>().ReverseMap();
            
        }
    }
}