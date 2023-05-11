using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CrossEventos.Application.Contratos;
using CrossEventos.Application.Dtos;
using CrossEventos.Domain;
using CrossEventos.Persistence.Contrato;

namespace CrossEventos.Application
{
    public class EventoService : IEventosService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;
        private readonly IMapper _mapper;
        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _eventoPersist = eventoPersist;
            _mapper = mapper;
        }

        public async Task<EventoDto> AddEventos(EventoDto model)
        {
            
           try
            {
                var evento = _mapper.Map<Evento>(model);

                _geralPersist.Add<Evento>(evento);

                if (await _geralPersist.SaveChangeAsync())
                {
                    var retorno = await _eventoPersist.GetEventosByIdAsync(evento.id, false);
                    return _mapper.Map<EventoDto>(retorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

         public async Task<EventoDto> UpdateEventos(int eventoId, EventoDto model)
        {
            
            try
            {
                var evento = await _eventoPersist.GetEventosByIdAsync(eventoId, false);
                if (evento == null)
                {
                    return null;
                }

                model.id = evento.id;

                _mapper.Map(model, evento);

                _geralPersist.Update<Evento>(evento);
                if (await _geralPersist.SaveChangeAsync())
                {
                    var eventoRetorno = await _eventoPersist.GetEventosByIdAsync(evento.id, false);
                    return _mapper.Map<EventoDto>(eventoRetorno);
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

        public async Task<EventoDto[]> GetAllEventosAsync(bool includePromotores = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosAsync(includePromotores);
                if (eventos == null) 
                {
                    return null;
                }
                 var resultado =_mapper.Map<EventoDto[]>(eventos);

                return resultado;
            }
           catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto[]> GetAllEventosByNomeAsync(string nome, bool includePromotores = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosByNomeAsync(nome, includePromotores);
                if (eventos == null) 
                {
                    return null;
                }
                var resultado =_mapper.Map<EventoDto[]>(eventos);

                return resultado;
            }
           catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto> GetEventosByIdAsync(int eventoid, bool includePromotores = false)
        {
            try
            {
                var evento = await _eventoPersist.GetEventosByIdAsync(eventoid, includePromotores);
                if (evento == null) 
                {
                    return null;
                }

            var resultado =_mapper.Map<EventoDto>(evento);

                return resultado;
            }
           catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       
    }
}