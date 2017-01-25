namespace Day3__01._25._17.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommentToReview : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "Comment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "Comment");
        }
    }
}
