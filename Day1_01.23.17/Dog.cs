using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_01._23._17
{
    //Can't use multiple base Classes but you can use multiple Interfaces
    public class Dog : ISpeakable 
    {
        public void Speak()
        {
            Bark();
        }

        private void Bark()
        {
            Console.WriteLine("Arrf Arrf!");
        }
    
    }
}
