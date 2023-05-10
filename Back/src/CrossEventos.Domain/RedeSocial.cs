using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrossEventos.Domain;

namespace CrossEventos.Domain
{
    public class RedeSocial
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string URL { get; set; }
        public int? EventoID { get; set; }
        public Evento? Evento { get; set; }
        public int? PromotorId { get; set; }
        public Promotor? Promotor { get; set; }

    }
}