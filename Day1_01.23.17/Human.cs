using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_01._23._17
{
    public class Human : ISpeakable
    {
        public string password;

        public Human(string _password)
        {
            password = _password;
        }

        public void Speak()
        {
            Talk();
        }

        private void Talk()
        {
            Console.WriteLine("Hello world!");
        }

    }
}
