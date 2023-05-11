using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrossEventos.Application.Dtos
{
    public class RedeSocialDto
    {
        public int id { get; set; }
        
        [Required(ErrorMessage ="O campo {0} é obrigatório"),
         StringLength(50, MinimumLength = 3,
                          ErrorMessage ="Intervalo permitido de 3 a 50 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        public string URL { get; set; }
        public int? EventoID { get; set; }
        public EventoDto? Evento { get; set; }
        public int? PromotorId { get; set; }
        public PromotorDto? Promotor { get; set; }
    }
}