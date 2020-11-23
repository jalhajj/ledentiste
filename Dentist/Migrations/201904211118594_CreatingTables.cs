namespace Dentist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatingTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MobileNumber = c.String(),
                        Address = c.String(),
                        Gender = c.String(),
                        MedicalHistory = c.String(),
                        Balance = c.Double(nullable: false),
                        Allergies = c.String(),
                        Alert = c.String(),
                        LastAppointment = c.DateTime(nullable: false),
                        NextAppointment = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PatientID);
            
            CreateTable(
                "dbo.Treatments",
                c => new
                    {
                        TreatmentID = c.Int(nullable: false, identity: true),
                        TeatmentType = c.String(),
                        Cost = c.Double(nullable: false),
                        MyProperty = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Note = c.String(),
                        PatientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TreatmentID);
            
            CreateTable(
                "dbo.Xrays",
                c => new
                    {
                        XrayID = c.Int(nullable: false, identity: true),
                        XrayFileName = c.String(),
                        XrayPath = c.String(),
                        PatientID = c.Int(nullable: false),
                        TreatmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.XrayID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Xrays");
            DropTable("dbo.Treatments");
            DropTable("dbo.Patients");
        }
    }
}
