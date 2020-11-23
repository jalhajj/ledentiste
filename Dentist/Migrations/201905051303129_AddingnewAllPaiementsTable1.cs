namespace Dentist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingnewAllPaiementsTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PaiementsTreatmentsPatients", "PatientID", c => c.Int(nullable: false));
            DropColumn("dbo.PaiementsTreatmentsPatients", "PatiendID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PaiementsTreatmentsPatients", "PatiendID", c => c.Int(nullable: false));
            DropColumn("dbo.PaiementsTreatmentsPatients", "PatientID");
        }
    }
}
