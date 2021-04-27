using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiscSegPre.Application.Models
{
    public class InspecaoModel
    {
        public int id_inspecao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "Distância da Comunidade")]
        public string distanciaComunidade { get; set; }

        [Display(Name = "Motivo Reprovação")]
        public string motivoReprovacao { get; set; }

        [Display(Name = "Nota")]
        [Column(TypeName = "decimal(18, 0)")]
        public decimal nota { get; set; }

        [Display(Name = "Situação")]
        public string situacao { get; set; }

        [Display(Name = "Foto Prédio")]
        public string fotoPredio { get; set; }

        [Display(Name = "Foto Apartamento")]
        public string fotoApartamento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "Cliente")]
        public int id_cliente { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "Prédio")]
        public int id_predio { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "Apartamento")]
        public int id_apartamento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "Bairro")]
        public int id_local { get; set; }

        public int id_select { get; set; } = 0;

        public int id_notaMeioProtecaoTecnico { get; set; }
        public int id_notaMeioProtecaoFisico { get; set; }
        public int id_notaAvaliacaoProcedimento { get; set; }
        public int id_notaMeioProtecaoHumano { get; set; }

        [Display(Name = "Data Cadastro")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime dt_cadastro { get; set; }

        [Display(Name = "Apartamento")]
        public  ApartamentoModel id_apartamentoNavigation { get; set; }

        [Display(Name = "Bairro")]
        public  LocalModel id_localNavigation { get; set; }

        [Display(Name = "Cliente")]
        public  ClienteModel id_clienteNavigation { get; set; }

        [Display(Name = "Prédio")]
        public  PredioModel id_predioNavigation { get; set; }

        public  NotaMeioProtecaoFisicoModel id_notaMeioProtecaoFisicoNavigation { get; set; }
        public NotaMeioProtecaoHumanoModel id_notaMeioProtecaoHumanoNavigation { get; set; }
        public NotaMeioProtecaoTecnicoModel id_notaMeioProtecaoTecnicoNavigation { get; set; }
        public  NotaAvaliacaoProcedimentoModel id_notaAvaliacaoProcedimentoNavigation { get; set; }
    }
}
