using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_01._23._17
{
    enum Car
    {
        Red,
        Green,
        Blue
    }

    enum Make
    {
        Toyota,
        Honda
    }
    
    class Program
    {   
        static void Main(string[] args)
        {

            /*
        * -------------- INTERFACES ----------------
        * You can define the signature and return
        * type of methods in multiple classes.
        * 
        * Two Steps: Definition & Implementation
        * 
        * Class Human                  Class Dog
        *  -void Speak()                 -void Speak()
        *  -private void Talk()          -private void Bark()
        * 
        *      static void MakeSpeak(<T> animal)
        *          animal.Speak();
        *      
        * How do you call animal.Speak() 
        * without making Human or Dog a subclass?
        *      
        * Use an Interface!
        * 
        * Remove void Speak() from Humand and Dog and 
        * create ISpeakable <- Interface
        * 
        */
            var joel = new Human("lol");
            var peanut = new Dog();

            MakeSpeak(joel);


            /*
             * -------------- DICTIONARIES ----------------
             * Key/Value pair
             * 
             * Dictionary<string, int>
             *  "Joel" : 40,
             *  "Sarah" : 4,
             * 
             * Point: fast, humanized retreivables
             * 
             */
            var myDictionary = new Dictionary<string, string>();
            myDictionary.Add("Surface", "Microsoft");
            
            Console.WriteLine(myDictionary["surface"]); //Search by key

            string myKey = myDictionary.FirstOrDefault(x => x.Value == "Microsoft").Key;

            //------------Enum Dictionary--------------//

            var enumDict = new Dictionary<Car, Make>();
            enumDict.Add(Car.Red, Make.Honda);

            //-----------Conversion Values Dictionary-------------//

            var conversionDict = new Dictionary<string, double>();
            conversionDict.Add("BTC", .0003);
            Console.WriteLine(5 * conversionDict["BTC"]);

            //-----------Password Match with Dictionary-------------//
            var humanDict = new Dictionary<string, Human>();
            humanDict.Add("Joel", new Human("peanutbutter"));
            humanDict.Add("Sarah", new Human("1234"));

            string username = Console.ReadLine();
            string password = Console.ReadLine();

            if (humanDict.Keys.Contains(username))
            {
                if (humanDict[username].password == password)
                {
                    Console.WriteLine("You've been logged in.");
                }
                else
                {
                    Console.WriteLine("Stop trying to break in!");
                }
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        static void MakeSpeak(ISpeakable animal)
        {
            animal.Speak();
        }


    }
}
