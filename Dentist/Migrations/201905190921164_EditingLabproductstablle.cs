namespace Dentist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditingLabproductstablle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LabProducts", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LabProducts", "Date");
        }
    }
}
