namespace Dentist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyingTheModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Treatments", "Paid", c => c.Double(nullable: false));
            AlterColumn("dbo.Patients", "LastAppointment", c => c.DateTime());
            AlterColumn("dbo.Patients", "NextAppointment", c => c.DateTime());
            DropColumn("dbo.Treatments", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Treatments", "MyProperty", c => c.Int(nullable: false));
            AlterColumn("dbo.Patients", "NextAppointment", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Patients", "LastAppointment", c => c.DateTime(nullable: false));
            DropColumn("dbo.Treatments", "Paid");
        }
    }
}
