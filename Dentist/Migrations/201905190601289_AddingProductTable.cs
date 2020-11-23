namespace Dentist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingProductTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        ProductDescription = c.String(),
                        Price = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
