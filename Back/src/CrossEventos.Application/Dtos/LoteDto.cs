using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrossEventos.Application.Dtos
{
    public class LoteDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="O campo {0} é obrigatório"),
         StringLength(50, MinimumLength = 3,
                          ErrorMessage ="Intervalo permitido de 3 a 50 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        public string DataInicio { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        public string DataFim { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório"),
            Range(1, 10000, ErrorMessage ="{0} não pode ser menor que 1 e maior que 10.000")]
        public int Quantidade { get; set; }
        public int EventoID { get; set; }
        public EventoDto? Evento { get; set; }
    }
}