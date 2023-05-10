using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrossEventos.Domain;

namespace CrossEventos.Persistence.Contrato
{
    public interface IEventoPersist
    {
       
        //interface Eventos
        Task<Evento[]> GetAllEventosByNomeAsync(string nome, bool includePromotores = false);
        Task<Evento[]> GetAllEventosAsync(bool includePromotores = false);
        Task<Evento> GetEventosByIdAsync(int eventoid, bool includePromotores = false);


    }
}