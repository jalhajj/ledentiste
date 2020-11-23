namespace Dentist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingTreatmentTypeAndMedDB1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Patients", name: "Medicalhistory_MedicalHistoryID", newName: "MedicalHistoryNote_MedicalHistoryID");
            RenameIndex(table: "dbo.Patients", name: "IX_Medicalhistory_MedicalHistoryID", newName: "IX_MedicalHistoryNote_MedicalHistoryID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Patients", name: "IX_MedicalHistoryNote_MedicalHistoryID", newName: "IX_Medicalhistory_MedicalHistoryID");
            RenameColumn(table: "dbo.Patients", name: "MedicalHistoryNote_MedicalHistoryID", newName: "Medicalhistory_MedicalHistoryID");
        }
    }
}
