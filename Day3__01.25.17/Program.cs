using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3__01._25._17
{
    class Program
    {
        static void Main(string[] args)
        {
            /*------------ PROPERTIES ------------
             * 
             */

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
