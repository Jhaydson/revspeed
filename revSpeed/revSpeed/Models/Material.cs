using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace revSpeed.Models
{
    public class Material
    {
        public int MaterialId { get; set; }

        [Required]
        [Display(Name = "Material")]
        [MaxLength(50, ErrorMessage = "O Campo {0} recebe no máximo 50 caracteres")]
        [Index("Nome_index", IsUnique = true)]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Composição")]
        [MaxLength(50, ErrorMessage = "O Campo {0} recebe no máximo 50 caracteres")]
        [Index("Composicao_index", IsUnique = true)]
        public string Composicao { get; set; }


        [Column(TypeName = "DateTime2")]
        [HiddenInput(DisplayValue = false)]
        [ScaffoldColumn(false)]
        public DateTime DataCreate { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}