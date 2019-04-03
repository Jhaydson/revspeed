using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace revSpeed.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }

        public Produto()
        {
            this.Tamanhos = new HashSet<Tamanho>().ToList();
        }


        [Required]
        [Display(Name = "Nome:")]
        [MaxLength(50, ErrorMessage = "O Campo {0} recebe no máximo 50 caracteres")]
        [Index("Nome_index", IsUnique = true)]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Codigo Produto:")]
        [MaxLength(50, ErrorMessage = "O Campo {0} recebe no máximo 50 caracteres")]
        [Index("Codigo_Produto_Index", IsUnique = true)]
        public string CodProduto { get; set; }

        [Display(Name = "Imagem do Produto")]
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }


        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }


        [Required]
        [Display(Name = "Valor de Venda:")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double ValorVenda { get; set; }


        [Display(Name = "Sugestão de Preço:")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double SugestaoPreco { get; set; }

        [Required]
        [Display(Name = "Cor:")]
        public int CorId { get; set; }

        [Required]
        [Display(Name = "Coleção:")]
        public int ColecaoId { get; set; }

        [Required]
        [Display(Name = "Material:")]
        public int MaterialId { get; set; }

        public double Pontos { get; set; }



        //Relacionamentos
        public virtual Cor Cores { get; set; }
        public virtual Colecao Colecoes { get; set; }
        public virtual Material Materias { get; set; }

        public List<Tamanho> Tamanhos { get; set; }

        [Column(TypeName = "DateTime2")]
        [HiddenInput(DisplayValue = false)]
        [ScaffoldColumn(false)]
        [Display(Name = "Data de Criação:")]
        public DateTime DataCreate { get; set; }

        public virtual ICollection<CustoProduto> CustosP { get; set; }
    }
}