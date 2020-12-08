using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiscSegPre.Domain.Entities
{
    public partial class Inspecao
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
        public int id_bairro { get; set; }

        public int id_select  { get; set; }

        public int id_notaMeioProtecaoTecnico { get; set; }
        public int id_notaMeioProtecaoFisico { get; set; }
        public int id_notaAvaliacaoProcedimento { get; set; }
        public int id_notaMeioProtecaoHumano { get; set; }

        [Display(Name = "Data Cadastro")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime dt_cadastro { get; set; }

        [Display(Name = "Apartamento")]
        public virtual Apartamento id_apartamentoNavigation { get; set; }

        [Display(Name = "Bairro")]
        public virtual Bairro id_bairroNavigation { get; set; }

        [Display(Name = "Cliente")]
        public virtual Cliente id_clienteNavigation { get; set; }

        [Display(Name = "Prédio")]
        public virtual Predio id_predioNavigation { get; set; }


        public virtual NotaMeioProtecaoFisico id_notaMeioProtecaoFisicoNavigation { get; set; }
        public virtual NotaMeioProtecaoHumano id_notaMeioProtecaoHumanoNavigation { get; set; }
        public virtual NotaMeioProtecaoTecnico id_notaMeioProtecaoTecnicoNavigation { get; set; }
        public virtual NotaAvaliacaoProcedimento id_notaAvaliacaoProcedimentoNavigation { get; set; }

    }
}
