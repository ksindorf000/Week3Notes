using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3__01._25._17
{
    class Program
    {
        /*------------ ENTITY FRAMEWORK ------------
         * https://drive.google.com/file/d/0B8ie37YIHMJURFpmZHVSTDgtbkU/view?usp=sharing
         * 
         * Project =>  Manage NuGet Packages => EntityFramework => Install
         * 
         * "Context" = Relationship between code and database
         * 
         * SQL Server Object Explorer
         */

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

                db.Movie.Add(movie);
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
