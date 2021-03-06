﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        [Column(TypeName = "DateTime2")]
        [HiddenInput(DisplayValue = false)]
        [ScaffoldColumn(false)]
        public DateTime DataCreate { get; set; }

        //Relacionamentos
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}