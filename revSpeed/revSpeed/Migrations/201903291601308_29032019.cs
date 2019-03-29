namespace revSpeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _29032019 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Colecaos",
                c => new
                    {
                        ColecaoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Lancamento = c.DateTime(nullable: false),
                        DataCreate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ColecaoId)
                .Index(t => t.Nome, unique: true, name: "Cor_index");
            
            CreateTable(
                "dbo.Cors",
                c => new
                    {
                        CorId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        DataCreate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.CorId)
                .Index(t => t.Nome, unique: true, name: "Cor_index");
            
            CreateTable(
                "dbo.Tamanhoes",
                c => new
                    {
                        TamanhoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        DataCreate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.TamanhoId)
                .Index(t => t.Nome, unique: true, name: "Tamanho_index");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tamanhoes", "Tamanho_index");
            DropIndex("dbo.Cors", "Cor_index");
            DropIndex("dbo.Colecaos", "Cor_index");
            DropTable("dbo.Tamanhoes");
            DropTable("dbo.Cors");
            DropTable("dbo.Colecaos");
        }
    }
}
