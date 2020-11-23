namespace Dentist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingPaiementModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Paiements",
                c => new
                    {
                        PaiementID = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        PaidDate = c.DateTime(),
                        PatientID = c.Int(nullable: false),
                        TreatmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaiementID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Paiements");
        }
    }
}
