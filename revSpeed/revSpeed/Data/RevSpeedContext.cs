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
    }
}