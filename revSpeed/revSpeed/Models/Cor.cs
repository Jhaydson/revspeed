using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace revSpeed.Models
{
    public class Cor
    {
        public int CorId { get; set; }

        [Required]
        [Display(Name = "Cor")]
        [MaxLength(50, ErrorMessage = "O Campo {0} recebe no máximo 50 caracteres")]
        [Index("Cor_index", IsUnique = true)]
        public string Nome { get; set; }

    }
}