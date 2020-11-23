namespace Dentist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingLabproductstablle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LabProducts",
                c => new
                    {
                        LabProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        CostOnPatient = c.Double(nullable: false),
                        Cost = c.Double(nullable: false),
                        PatientID = c.Int(nullable: false),
                        TreatmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LabProductID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LabProducts");
        }
    }
}
