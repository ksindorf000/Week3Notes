namespace Day3__01._25._17.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Genre = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        IMDB = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Occupation = c.String(),
                        Age = c.Int(nullable: false),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Movie_Id = c.Int(),
                        Person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Movie_Id)
                .Index(t => t.Person_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "Person_Id", "dbo.People");
            DropForeignKey("dbo.Reviews", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Reviews", new[] { "Person_Id" });
            DropIndex("dbo.Reviews", new[] { "Movie_Id" });
            DropTable("dbo.Reviews");
            DropTable("dbo.People");
            DropTable("dbo.Movies");
        }
    }
}
