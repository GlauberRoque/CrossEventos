using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrossEventos.Domain;

namespace CrossEventos.Persistence.Contrato
{
    public interface IGeralPersist
    {
        //interface geral 
        void Add<t>(t entity) where t: class;
        void Update<t>(t entity) where t: class;
        void Delete<t>(t entity) where t: class;
        void DeleteRange<t>(t entity) where t: class;

        Task<bool> SaveChangeAsync();

    }
}