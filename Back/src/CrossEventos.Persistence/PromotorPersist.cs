using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrossEventos.Domain;
using CrossEventos.Persistence.Contexto;
using CrossEventos.Persistence.Contrato;
using Microsoft.EntityFrameworkCore;

namespace CrossEventos.Persistence
{
    public class PromotorPersist : IPromotorPersist
    {
        private readonly CrossEventosContext _context;
        public PromotorPersist(CrossEventosContext context){
            _context = context;
        }
        
        public async Task<Promotor[]> GetAllPromotoresAsync(bool includeEventos = false)
        {
            IQueryable<Promotor> query = _context.Promotores
                                .Include(p => p.RedesSociais);

            if (includeEventos)
            {
                query = query.Include(p => p.PromotoresEventos)
                             .ThenInclude(pe => pe.Evento);
            }                    
            
            query = query.AsNoTracking().OrderBy(e => e.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Promotor[]> GetAllPromotoresByNomeAsync(string nome, bool includeEventos )
        {
              IQueryable<Promotor> query = _context.Promotores
                                .Include(p => p.RedesSociais);

            if (includeEventos){
                query = query.Include(p => p.PromotoresEventos)
                             .ThenInclude(pe => pe.Promotor);
            }                    
            
            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Nome.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<Promotor> GetPromotorByIdAsync(int Promotorid, bool includeEventos)
        {
            IQueryable<Promotor> query = _context.Promotores
                                .Include(e => e.RedesSociais);

            if (includeEventos){
                query = query.Include(e => e.PromotoresEventos)
                             .ThenInclude(pe => pe.Promotor);
            }                    
            
            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Id == Promotorid);
            return await query.FirstOrDefaultAsync();
        }

        
    }
}