namespace Dentist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingTreatmentTypeAndMedDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MedicalHistories",
                c => new
                    {
                        MedicalHistoryID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.MedicalHistoryID);
            
            CreateTable(
                "dbo.TreatmentTypes",
                c => new
                    {
                        TreatmentTypeID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.TreatmentTypeID);
            
            AddColumn("dbo.Patients", "Medicalhistory_MedicalHistoryID", c => c.Int());
            CreateIndex("dbo.Patients", "Medicalhistory_MedicalHistoryID");
            AddForeignKey("dbo.Patients", "Medicalhistory_MedicalHistoryID", "dbo.MedicalHistories", "MedicalHistoryID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "Medicalhistory_MedicalHistoryID", "dbo.MedicalHistories");
            DropIndex("dbo.Patients", new[] { "Medicalhistory_MedicalHistoryID" });
            DropColumn("dbo.Patients", "Medicalhistory_MedicalHistoryID");
            DropTable("dbo.TreatmentTypes");
            DropTable("dbo.MedicalHistories");
        }
    }
}
