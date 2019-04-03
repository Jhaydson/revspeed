using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace revSpeed.Models.ViewsModels
{
    public class ProdutoViewModel
    {
        public Produto Produtos { get; set; }
        public CustoProduto Custos { get; set; }
        public Tamanho Tamanhos { get; set; }
    }
}