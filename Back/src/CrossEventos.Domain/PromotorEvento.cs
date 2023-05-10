using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrossEventos.Domain
{
    public class PromotorEvento
    {
        public int PromotorId { get; set; }
        public Promotor Promotor { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
    }
}