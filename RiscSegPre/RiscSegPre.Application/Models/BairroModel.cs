using RiscSegPre.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RiscSegPre.Application.Models
{
    public class BairroModel
    {
        public int id_bairro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "Nome")]
        public string nm_bairro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "Cidade")]
        public string cidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "Estado")]
        public string estado { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "CISP")]
        public string cisp { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "RISP")]
        public string risp { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "AISP")]
        public string aisp { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "Ocorrências")]
        public string ocorrencias { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Data Atualização")]
        public DateTime? dt_atualizacao { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data Cadastro")]
        public DateTime dt_cadastro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "Delegacia")]
        public int id_delegacia { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "Batalhão")]
        public int id_batalhao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "Risco")]
        public int id_risco { get; set; }

        [Display(Name = "Batalhão")]
        public virtual BatalhaoPoliciaMilitar id_batalhaoNavigation { get; set; }

        [Display(Name = "Delegacia")]
        public virtual DelegaciaPoliciaCivil id_delegaciaNavigation { get; set; }

        [Display(Name = "Risco")]
        public virtual Risco id_riscoNavigation { get; set; }

        public virtual ICollection<Inspecao> Inspecao { get; set; }
    }
}
