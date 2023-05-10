using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CrossEventos.Domain
{
    public class Evento
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Local { get; set; }
        public DateTime? DataEvento { get; set; }
        public int QtdPessoas { get; set; }
        public string ImagemURL { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public IEnumerable<Lote>? Lotes { get; set; }
        public IEnumerable<RedeSocial>? RedesSociais { get; set; }
        public IEnumerable<PromotorEvento>? PromotoresEventos { get; set; }
        
      
    }
}