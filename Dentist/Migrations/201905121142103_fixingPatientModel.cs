namespace Dentist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixingPatientModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Patients", name: "MedicalHistoryNote_MedicalHistoryID", newName: "MedicalHistoryModel_MedicalHistoryID");
            RenameIndex(table: "dbo.Patients", name: "IX_MedicalHistoryNote_MedicalHistoryID", newName: "IX_MedicalHistoryModel_MedicalHistoryID");
            AddColumn("dbo.Patients", "medicalHistoryNote", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "medicalHistoryNote");
            RenameIndex(table: "dbo.Patients", name: "IX_MedicalHistoryModel_MedicalHistoryID", newName: "IX_MedicalHistoryNote_MedicalHistoryID");
            RenameColumn(table: "dbo.Patients", name: "MedicalHistoryModel_MedicalHistoryID", newName: "MedicalHistoryNote_MedicalHistoryID");
        }
    }
}
