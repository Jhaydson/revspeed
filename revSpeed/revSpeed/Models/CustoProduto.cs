using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace revSpeed.Models
{
    public class CustoProduto
    {
        public int CustoProdutoId { get; set; }
        
        [Range(10, 9999.99,
            ErrorMessage = "O preço de custo da malha deve ser entre " + "10,00 a 99999,99.")]
        [DisplayName("Preço da Malha")]
        public decimal? Malha { get; set; }
 
        public double Corte { get; set; }

        public double Costura { get; set; }

        public double Estampa { get; set; }

        public double ValorCusto { get; set; }

        public double MargemLucro { get; set; }
    }
}