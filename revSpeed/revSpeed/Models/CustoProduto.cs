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

        [DisplayName("Preço da Malha")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double Malha { get; set; }

        [DisplayName("Preço do Corte")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double Corte { get; set; }

        [DisplayName("Preço da Costura")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double Costura { get; set; }

        [DisplayName("Preço da Estampa")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double Estampa { get; set; }

        [DisplayName("Valor Total de Custos")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double ValorCusto { get; set; }

        [DisplayName("Margem de Lucro")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double MargemLucro { get; set; }

        public int ProdutoId { get; set; }

        public virtual Produto Produtos { get; set; }

    }
}