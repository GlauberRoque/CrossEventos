using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrossEventos.Domain;
using CrossEventos.Persistence.Contrato;
using CrossEventos.Persistence.Contexto;
using Microsoft.EntityFrameworkCore;

namespace CrossEventos.Persistence
{
    public class EventoPersist : IEventoPersist
    {
        private readonly CrossEventosContext _context;
        public EventoPersist(CrossEventosContext context){
            _context = context;
            //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
       
//
        public async Task<Evento[]> GetAllEventosAsync(bool includePromotores = false)
        {
            IQueryable<Evento> query = _context.Eventos
                                .Include(e => e.Lotes)
                                .Include(e => e.RedesSociais);

            if (includePromotores){
                query = query.Include(e => e.PromotoresEventos)
                             .ThenInclude(pe => pe.Promotor);
            }                    
            
            query = query.AsNoTracking().OrderBy(e => e.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByNomeAsync(string nome, bool includePromotores = false)
        {
             IQueryable<Evento> query = _context.Eventos
                                .Include(e => e.Lotes)
                                .Include(e => e.RedesSociais);

            if (includePromotores){
                query = query.Include(e => e.PromotoresEventos)
                             .ThenInclude(pe => pe.Promotor);
            }                    
            
            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Nome.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();
        }

        
        public async Task<Evento> GetEventosByIdAsync(int EventoId, bool includePromotores = false)
        {
            IQueryable<Evento> query = _context.Eventos
                                .Include(e => e.Lotes)
                                .Include(e => e.RedesSociais);

            if (includePromotores){
                query = query.Include(e => e.PromotoresEventos)
                             .ThenInclude(pe => pe.Promotor);
            }                    
            
            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Id == EventoId);
            return await query.FirstOrDefaultAsync();
        }

        //


    }
}