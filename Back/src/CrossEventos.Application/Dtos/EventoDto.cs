using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrossEventos.Application.Dtos
{
    public class EventoDto
    {
         public int id { get; set; }

         [Required(ErrorMessage ="O campo {0} é obrigatório"),
         StringLength(50, MinimumLength = 3,
                          ErrorMessage ="Intervalo permitido de 3 a 50 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        public string Local { get; set; }

        public string DataEvento { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório"),
            Range(1, 10000, ErrorMessage ="{0} não pode ser menor que 1 e maior que 10.000")]
        public int QtdPessoas { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$",
                ErrorMessage="Não é uma imagem cálida. (gif, jpg, jpeg, bmp ou png)")]
        public string ImagemURL { get; set; }

            [Required(ErrorMessage ="O campo {0} é obrigatório"),
            Phone(ErrorMessage ="O Campo telefone está com número inválido.")]
        public string Telefone { get; set; }

         [Required(ErrorMessage ="O campo {0} é obrigatório"),
          EmailAddress(ErrorMessage ="O Campo Email precisa ser um Email válido.")]
        public string Email { get; set; }

        
        public IEnumerable<LoteDto>? Lotes { get; set; }
        public IEnumerable<RedeSocialDto>? RedesSociais { get; set; }
        public IEnumerable<PromotorDto>? Promotores { get; set; }
    }
}