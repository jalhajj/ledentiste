namespace Dentist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changingthetreamentmodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Treatments", "Status", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Treatments", "Status", c => c.Boolean(nullable: false));
        }
    }
}
