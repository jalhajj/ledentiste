namespace Dentist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingTreatmentPlan : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TreatmentPlans",
                c => new
                    {
                        TreatmentPlanID = c.Int(nullable: false, identity: true),
                        TreatmentDescription = c.String(),
                        PatientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TreatmentPlanID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TreatmentPlans");
        }
    }
}
