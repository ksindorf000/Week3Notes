namespace Day3__01._25._17.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DroppedCommentColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Reviews", "Comment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "Comment", c => c.String());
        }
    }
}
