namespace Dentist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyingtheXraytable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Xrays", "UploadDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Xrays", "FileContentType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Xrays", "FileContentType");
            DropColumn("dbo.Xrays", "UploadDate");
        }
    }
}
