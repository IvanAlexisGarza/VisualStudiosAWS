namespace Softtek.Academy2018.ToDoListApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class schema_changes_init_config : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "Title", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Items", "Description", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Status", "Description", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Tags", "Name", c => c.String(nullable: false, maxLength: 250));
            DropColumn("dbo.Items", "IsActive");
            DropColumn("dbo.Status", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Status", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Items", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tags", "Name", c => c.String());
            AlterColumn("dbo.Status", "Description", c => c.String());
            AlterColumn("dbo.Items", "Description", c => c.String());
            AlterColumn("dbo.Items", "Title", c => c.String());
        }
    }
}
