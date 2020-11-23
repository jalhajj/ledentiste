namespace Dentist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingpaymentDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LabProducts", "Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LabProducts", "Date", c => c.DateTime(nullable: false));
        }
    }
}
