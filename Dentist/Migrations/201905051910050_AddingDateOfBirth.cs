namespace Dentist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDateOfBirth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "DateOfBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "DateOfBirth");
        }
    }
}
