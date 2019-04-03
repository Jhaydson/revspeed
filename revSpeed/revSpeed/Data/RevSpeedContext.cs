using System.Data.Entity;

namespace revSpeed.Data
{
    public class RevSpeedContext : DbContext
    {
        public RevSpeedContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<revSpeed.Models.Cor> Cors { get; set; }

        public System.Data.Entity.DbSet<revSpeed.Models.Colecao> Colecaos { get; set; }

        public System.Data.Entity.DbSet<revSpeed.Models.Tamanho> Tamanhos { get; set; }

        public System.Data.Entity.DbSet<revSpeed.Models.Material> Materials { get; set; }

        public System.Data.Entity.DbSet<revSpeed.Models.Produto> Produtoes { get; set; }

        public System.Data.Entity.DbSet<revSpeed.Models.CustoProduto> CustoProdutoes { get; set; }

        


    }
}