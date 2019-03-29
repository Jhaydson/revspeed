using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace revSpeed.Models
{
    public class Tamanho
    {

        public int TamanhoId { get; set; }

        [Required]
        [Display(Name = "Tamanho")]
        [MaxLength(50, ErrorMessage = "O Campo {0} recebe no máximo 50 caracteres")]
        [Index("Tamanho_index", IsUnique = true)]
        public string Nome { get; set; }

        
        [Column(TypeName = "DateTime2")]
        [HiddenInput(DisplayValue = false)]
        [ScaffoldColumn(false)]
        public DateTime DataCreate { get; set; }
    }
}