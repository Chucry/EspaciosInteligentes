namespace EspaciosInteligentes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCityIdColumnToClientTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clients", "City_Id", "dbo.Cities");
            DropIndex("dbo.Clients", new[] { "City_Id" });
            RenameColumn(table: "dbo.Clients", name: "City_Id", newName: "CityId");
            AlterColumn("dbo.Clients", "CityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Clients", "CityId");
            AddForeignKey("dbo.Clients", "CityId", "dbo.Cities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "CityId", "dbo.Cities");
            DropIndex("dbo.Clients", new[] { "CityId" });
            AlterColumn("dbo.Clients", "CityId", c => c.Int());
            RenameColumn(table: "dbo.Clients", name: "CityId", newName: "City_Id");
            CreateIndex("dbo.Clients", "City_Id");
            AddForeignKey("dbo.Clients", "City_Id", "dbo.Cities", "Id");
        }
    }
}
