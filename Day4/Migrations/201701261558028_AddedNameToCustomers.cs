namespace Day4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNameToCustomers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Name");
        }
    }
}
