using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrossEventos.Application.Contratos;
using CrossEventos.Domain;
using CrossEventos.Persistence.Contrato;

namespace CrossEventos.Application
{
    public class EventoService : IEventosService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;
        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
        {
            _geralPersist = geralPersist;
            _eventoPersist = eventoPersist;
        }

        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _geralPersist.Add<Evento>(model);
                if (await _geralPersist.SaveChangeAsync())
                {
                    return await _eventoPersist.GetEventosByIdAsync(model.id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

         public async Task<Evento> UpdateEventos(int eventoId, Evento model)
        {
            try
            {
                var evento = await _eventoPersist.GetEventosByIdAsync(eventoId, false);
                if (evento == null)
                {
                    return null;
                }

                model.id = evento.id;

                _geralPersist.Update(model);
                if (await _geralPersist.SaveChangeAsync())
                {
                    return await _eventoPersist.GetEventosByIdAsync(model.id, false);
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEventos(int eventoId)
        {
            try
            {
                var evento = await _eventoPersist.GetEventosByIdAsync(eventoId, false);
                if (evento == null)
                {
                    throw new Exception("Evento não encontrado!");
                }

                _geralPersist.Delete<Evento>(evento);
                return await _geralPersist.SaveChangeAsync();
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePromotores = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosAsync(includePromotores);
                if (eventos == null) 
                {
                    return null;
                }
                return eventos;
            }
           catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByNomeAsync(string nome, bool includePromotores = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosByNomeAsync(nome, includePromotores);
                if (eventos == null) 
                {
                    return null;
                }
                return eventos;
            }
           catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventosByIdAsync(int eventoid, bool includePromotores = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetEventosByIdAsync(eventoid, includePromotores);
                if (eventos == null) 
                {
                    return null;
                }
                return eventos;
            }
           catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       
    }
}