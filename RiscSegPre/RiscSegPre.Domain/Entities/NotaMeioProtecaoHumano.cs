using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiscSegPre.Domain.Entities
{
    public partial class NotaMeioProtecaoHumano
    {
        public NotaMeioProtecaoHumano()
        {
            Inspecao = new HashSet<Inspecao>();
        }

        public int id_notaMeioProtecaoHumano { get; set; }

        //[DataType(DataType.Currency)]
        //[Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Guarda Segurança")]
        [Range(typeof(int), "0", "100", ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int guardaSeguranca { get; set; }

        [Display(Name = "Getão Vigilancia")]
        [Range(typeof(int), "0", "100", ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int gestaoServicoVigilancia { get; set; }

        
        [Display(Name = "Equipamento e Material")]
        [Range(typeof(int), "0", "100", ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int equipamentoMaterial { get; set; }

        [Display(Name = "Capacidade Operacional")]
        [Range(typeof(int), "0", "100", ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int capacidadeOperacional { get; set; }

        public virtual ICollection<Inspecao> Inspecao { get; set; }

        public decimal CalcularMedia(Inspecao inspecao)
        {
            var mediaProtecaoHumano = ((inspecao.id_notaMeioProtecaoHumanoNavigation.guardaSeguranca +
                                        inspecao.id_notaMeioProtecaoHumanoNavigation.gestaoServicoVigilancia +
                                        inspecao.id_notaMeioProtecaoHumanoNavigation.equipamentoMaterial +
                                        inspecao.id_notaMeioProtecaoHumanoNavigation.capacidadeOperacional) / 4);
            return mediaProtecaoHumano;
        }
    }
}
