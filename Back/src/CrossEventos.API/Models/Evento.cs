using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrossEventos.API.Models
{
    public class Evento
    {
        public int EventoID { get; set; }
        public string Nome { get; set; }
        public string Local { get; set; }
        public string DataEvento { get; set; }
        public int QtdPessoas { get; set; }
        public string ImagemURL { get; set; }
         
    }
}