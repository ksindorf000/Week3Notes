using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Day3__01._25._17
{
    public class MovieReviewContext : DbContext
    {
        //Gives BbContext awareness of our models
        //Basically the tables that are going to be created
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Review> Review { get; set; }
        
    }
}
