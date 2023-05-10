using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrossEventos.Domain;

namespace CrossEventos.Application.Contratos
{
    public interface IEventosService
    {
        Task<Evento> AddEventos(Evento model);
        Task<Evento> UpdateEventos(int eventoId, Evento model);
        Task<bool> DeleteEventos(int eventoId);

        Task<Evento[]> GetAllEventosAsync(bool includePromotores = false);
        Task<Evento[]> GetAllEventosByNomeAsync(string nome, bool includePromotores = false);
        Task<Evento> GetEventosByIdAsync(int Eventoid, bool includePromotores = false);
    }
}