namespace Dentist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnotherChangementTeeth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Treatments", "AddedBy", c => c.String());
            AlterColumn("dbo.Treatments", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Treatments", "Status", c => c.String());
            DropColumn("dbo.Treatments", "AddedBy");
        }
    }
}
