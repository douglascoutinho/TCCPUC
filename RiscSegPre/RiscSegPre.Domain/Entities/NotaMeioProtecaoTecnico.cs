using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiscSegPre.Domain.Entities
{
    public partial class NotaMeioProtecaoTecnico
    {
        public NotaMeioProtecaoTecnico()
        {
            Inspecao = new HashSet<Inspecao>();
        }

        public int id_notaMeioProtecaoTecnico { get; set; }

        //[DataType(DataType.Currency)]
        //[Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Sistema Detecção Intruso")]
        [Range(typeof(int), "0", "100", ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int sistemaDeteccaoIntruso { get; set; }

        [Display(Name = "Sistema Alarme Intruso")]
        [Range(typeof(int), "0", "100", ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int sistemaAlarmeIntruso { get; set; }

        [Display(Name = "Circuito Fechado de Video")]
        [Range(typeof(int), "0", "100", ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int circuitoFechadoVideo { get; set; }

        [Display(Name = "Controle de Acesso")]
        [Range(typeof(int), "0", "100", ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int sistemaControleAcesso { get; set; }

        [Display(Name = "Controle de Comunicação")]
        [Range(typeof(int), "0", "100", ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int sistemaComunicacao { get; set; }

        [Display(Name = "Sistema Controle Rodizio")]
        [Range(typeof(int), "0", "100", ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int sistemaControleRodizio { get; set; }
        
        [Display(Name = "Telemonitoramento")]
        [Range(typeof(int), "0", "100", ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int telemonitoramento { get; set; }

        public virtual ICollection<Inspecao> Inspecao { get; set; }

        public decimal CalcularMedia(Inspecao inspecao)
        {
            var mediaProtecaoTecnico = ((inspecao.id_notaMeioProtecaoTecnicoNavigation.sistemaDeteccaoIntruso +
                                         inspecao.id_notaMeioProtecaoTecnicoNavigation.sistemaAlarmeIntruso +
                                         inspecao.id_notaMeioProtecaoTecnicoNavigation.circuitoFechadoVideo +
                                         inspecao.id_notaMeioProtecaoTecnicoNavigation.sistemaControleAcesso +
                                         inspecao.id_notaMeioProtecaoTecnicoNavigation.sistemaComunicacao +
                                         inspecao.id_notaMeioProtecaoTecnicoNavigation.sistemaControleRodizio +
                                         inspecao.id_notaMeioProtecaoTecnicoNavigation.telemonitoramento) / 7);
            return mediaProtecaoTecnico;
        }
    }
}
