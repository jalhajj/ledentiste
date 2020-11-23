namespace Dentist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditingLabproductstablleTwo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LabProducts", "LabName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LabProducts", "LabName");
        }
    }
}
