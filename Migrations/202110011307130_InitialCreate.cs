namespace WebTeste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sexo",
                c => new
                {
                    SexoId = c.Int(nullable: false, identity: true),
                    Descricao = c.String(),
                })
                .PrimaryKey(t => t.SexoId);

            CreateTable(
                "dbo.Usuario",
                c => new
                {
                    UsuarioId = c.Int(nullable: false, identity: true),
                    Nome = c.String(nullable: false),
                    DataNascimento = c.String(nullable: false),
                    Email = c.String(nullable: false),
                    Senha = c.String(),
                    SexoId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.UsuarioId)
                .ForeignKey("dbo.Sexo", t => t.SexoId, cascadeDelete: true)
                .Index(t => t.SexoId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Usuario", "SexoId", "dbo.Sexo");
            DropIndex("dbo.Usuario", new[] { "SexoId" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Sexo");
        }
    }
}