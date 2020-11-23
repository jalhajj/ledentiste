namespace Dentist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingTreatmentDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Treatments", "Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Treatments", "Date", c => c.DateTime(nullable: false));
        }
    }
}
