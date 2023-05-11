using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrossEventos.Application.Dtos;
using CrossEventos.Domain;

namespace CrossEventos.Application.Contratos
{
    public interface IEventosService
    {
        Task<EventoDto> AddEventos(EventoDto model);
        Task<EventoDto> UpdateEventos(int eventoId, EventoDto model);
        Task<bool> DeleteEventos(int eventoId);

        Task<EventoDto[]> GetAllEventosAsync(bool includePromotores = false);
        Task<EventoDto[]> GetAllEventosByNomeAsync(string nome, bool includePromotores = false);
        Task<EventoDto> GetEventosByIdAsync(int Eventoid, bool includePromotores = false);
    }
}