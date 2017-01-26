using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3__01._25._17
{
    class Program
    {
        /*------------ ENTITY FRAMEWORK (EF) ------------
         * Diagram: 
         *    https://drive.google.com/file/d/0B8ie37YIHMJURFpmZHVSTDgtbkU/view?usp=sharing
         * 
         * Project =>  Manage NuGet Packages => EntityFramework => Install
         * 
         * Step 1) Install Entity Framework Package
         * Step 2) Create models
         * Step 3) Create Context.cs
         *        a) Context : DbContext
         *        b) using System.Data.Entity
         *        c) public DbSet<Class> TableName { get; set; }
         * Step 4) PMC >> Enable-Migrations
         * Step 5) PMC >> Add-Migration [Description]
         * Step 6) PMC >> Update-Database
         * 
         * "Context" = Relationship between code and database
         * 
         * SQL Server Object Explorer
         */

        /* MIGRATIONS:
         * 
         * View > Other Windows > Package Manager Console (PMS)
         * Set Default Project to current project
         * PMC >> Enable-Migrations
         *      Creates a Migrations Directory (Solution Explorer)
         *      LOOK AT THE TIMESTAMPS (migrations HAVE to be run in order)
         * 
         * DROP: Delete Table(s)
         * TRUNCATE: Delete data
         * UP: Do this (Add)
         * DOWN: Reverse the UP
         * 
         * SoluExp > Project > Migrations > COnfiguration.cs > SEED()
         *      Allows you to add data at db creation
         *      
         * UPDATE TABLE SCHEMA:
         *  Step 1) Make change to model
         *  Step 2) PMC >> Add-Migration [WhatThisUpdateIs]*
         *  Step 3) PMC >> Update-Database
         *  Step 4) Close/Reopen table data window to see change
         *  
         *      *This doesn't change the db. Just creates the migration script
         */

        //LINQ: How to query the db from EF

        static void Main(string[] args)
        {
            //"using" cleans up behind itself (closes file, db, etc)
            using (var db = new MovieReviewContext())
            {
                Movie movie = new Movie
                {
                    Title = "Days of Thunder",
                    Genre = "Drama",
                    ReleaseDate = DateTime.Today
                };

                Person myPerson = new Person
                {
                    Occupation = "Race Car Driver",
                    Age = 30
                };

                Review myReview = new Review
                {
                    Person = myPerson,
                    Movie = movie,
                    Rating = 7
                };

                db.Movie.Add(movie);
                db.Person.Add(myPerson);
                db.Review.Add(myReview);
                db.SaveChanges(); //Syncronus - Add changes to que, wait until this has been saved
                //db.SaveChangesAsync(); //Asyncronus - Add changes to que, go do other stuff
            }


            //CreateReviews();
        }

        /*------------ IntroToProperties --------------*/

        private static void CreateReviews()
        {
            //"Old" way
            //Person joel = new Person("programmer", 21, 'f');

            //Using properties
            Person joel = new Person
            {
                Age = 33,
                Gender = 'M',
                Occupation = "Programmer",
                City = "Greenville"
            };

            Person michael = new Person
            {
                Gender = 'M',
                Occupation = "Programmer",
                City = "Barcelona"
            };

            Movie LittleShop = new Movie
            {
                Title = "Little Shop of Horrors",
                Genre = "Musical",
                ReleaseDate = DateTime.Now
            };

            Review joelReview = new Review { Person = joel, Movie = LittleShop, Rating = 8 };
            Review michaelReview = new Review { Person = michael, Movie = LittleShop, Rating = 6 };

            Console.WriteLine(michaelReview);
            Console.WriteLine(joelReview);
        }
    }
}
