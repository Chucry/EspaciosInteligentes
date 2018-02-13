namespace EspaciosInteligentes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedTerminationDateColumnInEmployeeTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "TerminationDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "TerminationDate", c => c.DateTime(nullable: false));
        }
    }
}
