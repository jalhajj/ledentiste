namespace Dentist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingnewAllPaiementsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaiementsTreatmentsPatients",
                c => new
                    {
                        PaiementsTreatmentsPatientsID = c.Int(nullable: false, identity: true),
                        PaiementID = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                        PaiementDate = c.DateTime(),
                        PatientName = c.String(),
                        TreatmentType = c.String(),
                        PatiendID = c.Int(nullable: false),
                        TreatmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaiementsTreatmentsPatientsID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PaiementsTreatmentsPatients");
        }
    }
}
