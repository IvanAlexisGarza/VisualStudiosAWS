namespace Softtek.Academy2018.ToDoListApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class debeCOrrer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "DueDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "DueDate", c => c.DateTime());
        }
    }
}
