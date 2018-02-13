namespace EspaciosInteligentes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        ContactNumber = c.String(),
                        City_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .Index(t => t.City_Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                        Phone = c.String(),
                        Mobile = c.String(),
                        Department = c.String(),
                        Role = c.String(),
                        HireDate = c.DateTime(nullable: false),
                        TerminationDate = c.DateTime(nullable: true),
                        BaseSalary = c.Double(nullable: false),
                        Address = c.String(),
                        Address2 = c.String(),
                        SSN = c.String(),
                        CURP = c.String(),
                        CLABE = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lockers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Width = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        Depth = c.Int(nullable: false),
                        Store_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stores", t => t.Store_Id)
                .Index(t => t.Store_Id);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        Address2 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PromoCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Amount = c.Int(nullable: false),
                        Description = c.String(),
                        ExpirationDate = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        CreatedBy_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.CreatedBy_Id)
                .Index(t => t.CreatedBy_Id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: true),
                        Locker_Id = c.Int(),
                        Ticket_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lockers", t => t.Locker_Id)
                .ForeignKey("dbo.Tickets", t => t.Ticket_Id)
                .Index(t => t.Locker_Id)
                .Index(t => t.Ticket_Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Discount = c.Double(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        SubTotal = c.Double(nullable: false),
                        Taxes = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                        Client_Id = c.Int(),
                        PromoCode_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .ForeignKey("dbo.PromoCodes", t => t.PromoCode_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.PromoCode_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "Ticket_Id", "dbo.Tickets");
            DropForeignKey("dbo.Tickets", "PromoCode_Id", "dbo.PromoCodes");
            DropForeignKey("dbo.Tickets", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Sales", "Locker_Id", "dbo.Lockers");
            DropForeignKey("dbo.PromoCodes", "CreatedBy_Id", "dbo.Employees");
            DropForeignKey("dbo.Lockers", "Store_Id", "dbo.Stores");
            DropForeignKey("dbo.Clients", "City_Id", "dbo.Cities");
            DropIndex("dbo.Tickets", new[] { "PromoCode_Id" });
            DropIndex("dbo.Tickets", new[] { "Client_Id" });
            DropIndex("dbo.Sales", new[] { "Ticket_Id" });
            DropIndex("dbo.Sales", new[] { "Locker_Id" });
            DropIndex("dbo.PromoCodes", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Lockers", new[] { "Store_Id" });
            DropIndex("dbo.Clients", new[] { "City_Id" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Sales");
            DropTable("dbo.PromoCodes");
            DropTable("dbo.Stores");
            DropTable("dbo.Lockers");
            DropTable("dbo.Employees");
            DropTable("dbo.Clients");
            DropTable("dbo.Cities");
        }
    }
}
