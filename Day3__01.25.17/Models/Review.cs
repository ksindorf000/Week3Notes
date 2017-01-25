using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3__01._25._17 //Model Directory
{
    public class Review
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public Movie Movie { get; set; }
        public int Rating { get; set; }
        
        public override string ToString()
        {
            return $"Someone from {Person.City} rated {Movie.Title} {Rating}/10 stars";
        }

    }
}
