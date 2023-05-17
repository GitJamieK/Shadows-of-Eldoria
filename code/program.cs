using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {

        public static Player currentPlayer = new Player();
        static void Main(string[] args)
        {
            Start();
        }


        static void Start()
        {
            //choosing name

            Console.WriteLine("Welcome to Temp_Game!");
            Console.Write("Press any key to continue.\n>");
            Console.ReadKey();
            Console.Clear();
            bool isNameValid = false;
            while (isNameValid == false)
            {
                Console.WriteLine("What will your characters name be?");
            currentPlayer.name = Tools.ReadLine();
            Console.Clear();
                if (currentPlayer.name == "")
                {
                    Console.WriteLine("You do not know your own name.");
                    isNameValid = true;
                }    
                else
                {
                    Console.WriteLine("Are you sure you're name is "+ currentPlayer.name);
                    Console.WriteLine("Please type 'Yes' or 'No'");
                    string inputname = Tools.ReadLine();
                    if (inputname.ToLower() == "no")
                    {
                        isNameValid = false;
                    }

                    else if (inputname.ToLower() == "yes")
                    {
                        isNameValid = true;
                        Console.WriteLine("Your name is "+currentPlayer.name);
                    }
                }    
            }
            Console.Write("Press any key to continue.\n>");
            Console.ReadKey();
            Console.Clear();

            //lore start

            Console.WriteLine("");
        }
    }
}