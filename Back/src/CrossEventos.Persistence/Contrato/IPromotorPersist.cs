using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrossEventos.Domain;

namespace CrossEventos.Persistence.Contrato
{
    public interface IPromotorPersist
    {
        
        //Promotores
        Task<Promotor[]> GetAllPromotoresByNomeAsync(string nome, bool includeEventos);
        Task<Promotor[]> GetAllPromotoresAsync(bool includeEventos);
        Task<Promotor> GetPromotorByIdAsync(int Promotorid, bool includeEventos);

    }
}