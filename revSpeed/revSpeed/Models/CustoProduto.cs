using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace revSpeed.Models
{
    public class CustoProduto
    {
        public int CustoProdutoId { get; set; }

        [Display(Name = "Custo malha por peça")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float Malha { get; set; }


        [Display(Name = "Custo Corte por peça")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float Corte { get; set; }


        [Display(Name = "Custo Costura por peça")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float Costura { get; set; }


        [Display(Name = "Custo Estampa por peça")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float Estampa { get; set; }

        public float ValorCusto { get; set; }

        public float MargemLucro { get; set; }
    }
}