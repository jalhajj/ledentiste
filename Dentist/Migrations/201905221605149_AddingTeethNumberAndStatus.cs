namespace Dentist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingTeethNumberAndStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Treatments", "TeethNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Treatments", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Treatments", "Status");
            DropColumn("dbo.Treatments", "TeethNumber");
        }
    }
}
