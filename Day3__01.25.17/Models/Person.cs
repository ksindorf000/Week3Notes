using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3__01._25._17 //Model Directory
{
    public class Person
    {
        /*------------ PROPERTIES ------------*/

        //"Old" way (member and constructor)
        //public string Occupation;
        //public string Age;
        //public Person () {};

        //Property
        public int Id { get; set; }
        public string Occupation { get; set; } //Title-Case
        public int Age { get; set; }
        public char Gender { get; set; }
        public string City { get; set; }
        
    }
}
