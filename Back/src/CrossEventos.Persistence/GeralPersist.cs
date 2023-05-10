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
    public class GeralPersist : IGeralPersist
    {
        private readonly CrossEventosContext _context;
        public GeralPersist(CrossEventosContext context){
            _context = context;
        }
        public void Add<t>(t entity) where t : class
        {
            _context.Add(entity);
        }

         public void Update<t>(t entity) where t : class
        {
            _context.Update(entity);
        }

        public void Delete<t>(t entity) where t : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<t>(t entityArray) where t : class
        {
            _context.RemoveRange(entityArray);
        }

         public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }


    }
}